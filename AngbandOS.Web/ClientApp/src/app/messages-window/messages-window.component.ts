import { Component, NgZone, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import * as SignalR from "@microsoft/signalr";
import { PageOfGameMessages } from './page-of-game-messages';
import { GameMessage } from './game-message';
import { JsonPageOfGameMessages } from './json-page-of-game-messages';
import { JsonGameMessage } from './json-game-message';

@Component({
  selector: 'app-messages-window',
  templateUrl: './messages-window.component.html',
  styleUrls: ['./messages-window.component.scss']
})
export class MessagesWindowComponent implements OnInit {
  /** Returns the subscriptions that were created and which need to be unsubscribes when the component is destroyed. */
  private _initSubscriptions = new Subscription();

  /** Represents the unique identifier for the game to play; null, to start a new game; otherwise, undefined when the guid hasn't been retrieved yet. */
  public gameConnectionId: string | null | undefined = undefined;

  /** Returns the Signal-R connection to the MessagesHub. */
  private connection: SignalR.HubConnection | undefined;

  /** Returns the active Signal-R connection ID. */
  public connectionId: string | null = null;

  /** Returns the master array of messages that have been retrieved from the game. This structure is updated as new pages of messages are received. */
  public masterPageOfGameMessages: PageOfGameMessages | null = null;

  /** Returns the names of the columns that are being displayed. */
  public gameMessagesDisplayedColumns: string[] = ["text"];

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _router: Router,
    private _zone: NgZone
  )
  {
  }

  private validatePageOfGameMessages(jsonPageOfGameMessages: JsonPageOfGameMessages): PageOfGameMessages | null {
    // Validate the JSON structure.  We will skip validating each message until we perform a concatenation.
    if (jsonPageOfGameMessages.firstIndex === undefined || jsonPageOfGameMessages.lastIndex === undefined || jsonPageOfGameMessages.gameMessages === undefined) {
      return null;
    }

    var gameMessages: GameMessage[] = [];
    for (var i = 0; i < jsonPageOfGameMessages.gameMessages.length; i++) {
      const jsonGameMessage: JsonGameMessage = jsonPageOfGameMessages.gameMessages[i];
      if (jsonGameMessage.text === undefined || jsonGameMessage.count === undefined) {
        return null;
      }
      gameMessages.push(new GameMessage(jsonGameMessage.text, jsonGameMessage.count));
    }

    return new PageOfGameMessages(jsonPageOfGameMessages.firstIndex, jsonPageOfGameMessages.lastIndex, gameMessages);
  }

  ngOnInit(): void {
    // Connect to the messages hub.
    this.connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/game-messages-hub").build();

    // Retrieve the game guid from the query.
    this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap) => {
      this.gameConnectionId = paramMap.get("guid");

      if (this.connection !== undefined) {
        this.connection.start().then(() => {
          if (this.connection) {
            this.connectionId = this.connection.connectionId;

            this.connection.on("GameOver", () => {
              this._zone.run(() => {
                window.close();
              });
            });
            this.connection.on("GameMessagesUpdated", () => {
              this._zone.run(() => {
                this.refresh();
              });
            });
            this.connection.on("GameMessagesReceived", (jsonPageOfGameMessages: JsonPageOfGameMessages | null) => {
              this._zone.run(() => {
                // Check to see if we have any messages recevied from the game.
                if (jsonPageOfGameMessages != null) {
                  // Validate the JSON structure.
                  const pageOfGameMessages: PageOfGameMessages | null = this.validatePageOfGameMessages(jsonPageOfGameMessages);
                  if (pageOfGameMessages !== null) {
                    // Is this the initial load.
                    if (this.masterPageOfGameMessages === null) {
                      this.masterPageOfGameMessages = pageOfGameMessages;
                    } else {
                      // Update the master list of game messages.  Check to see if the page should be appended to the end.
                      if (pageOfGameMessages.lastIndex > this.masterPageOfGameMessages.firstIndex) {
                        // Check to see if there is a gap.  If a gap occurs, we will discard the existing page and restart.  Normally, messages are requested to ensure
                        // there is no gap from the existing master list.  If this gap should does occur, then there messages that were deleted from the game--the log is too long.
                        // In this scenario, we have to assume all previous messages are also gone.  So we will discard the master list and show what we have.
                        if (pageOfGameMessages.lastIndex > this.masterPageOfGameMessages.firstIndex + 1) {
                          // There is a gap.  Discard the master list.
                          this.masterPageOfGameMessages = pageOfGameMessages;
                        } else {
                          // There is no gap.  Append the messages.
                          this.masterPageOfGameMessages.gameMessages = this.masterPageOfGameMessages.gameMessages.concat(pageOfGameMessages.gameMessages!);
                          this.masterPageOfGameMessages.firstIndex = pageOfGameMessages.firstIndex;
                        }
                      } else if (pageOfGameMessages.firstIndex < this.masterPageOfGameMessages.lastIndex) { // Check to see if the page should be inserted at the beginning.
                        // Check to see if this is a gap.
                        if (pageOfGameMessages.firstIndex + 1 < this.masterPageOfGameMessages.lastIndex) {
                          // There is a gap.  Something unexpected happened with the request and there is nothing we can do.  We do not want to
                          // have in incorrect list.  We will simply ignore the page.
                        } else {
                          // There is no gap.  Concatenate the messages together.
                          this.masterPageOfGameMessages.gameMessages = pageOfGameMessages.gameMessages.concat(this.masterPageOfGameMessages.gameMessages);
                          this.masterPageOfGameMessages.lastIndex = pageOfGameMessages.lastIndex;
                        }
                      }
                    }
                  }
                }
              });
            });

            this.reload();
          }
        }, (error) => {

        });
      } else {

      }
    }));
  }

  public reload() {
    // Send a message to the hub to receive the current messages.
    this.masterPageOfGameMessages = null;
    if (this.connection) {
      this.connection.send("MonitorGameMessages", this.gameConnectionId, 20);
    }
  }

  public refresh() {
    // Send a message to the hub to receive the current messages.
    if (this.connection && this.masterPageOfGameMessages !== null) {
      this.connection.send("GetGameMessages", this.gameConnectionId, null, this.masterPageOfGameMessages.firstIndex + 1, null);
    }
  }

  ngOnDestroy() {
    if (this.connection) {
      this.connection.off("GameOver");
      this.connection.off("GameMessagesReceived");
      this.connection.stop();
      this._initSubscriptions.unsubscribe();
    }
  }
}
