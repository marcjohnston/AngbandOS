import { Component, ElementRef, NgZone, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import * as SignalR from "@microsoft/signalr";
import { PageOfGameMessages } from './page-of-game-messages';
import { GameMessage } from './game-message';
import { JsonPageOfGameMessages } from './json-page-of-game-messages';
import { JsonGameMessage } from './json-game-message';
import { MatRow } from '@angular/material/table';

@Component({
  selector: 'app-messages-window',
  templateUrl: './messages-window.component.html',
  styleUrls: ['./messages-window.component.scss']
})
export class MessagesWindowComponent implements OnInit {
  @ViewChildren(MatRow, { read: ElementRef }) tableRows!: QueryList<ElementRef<HTMLTableRowElement>>;
  @ViewChild('scrollDiv', { static: true }) private scrollDivRef: ElementRef<HTMLDivElement> | undefined;

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

  /** Returns true, upon intial load or reload.  When true, requests for messages are sent in an attempt to fill the screen height. */
  public fillMode = false;

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

    var gameMessages: string[] = [];
    for (var i = 0; i < jsonPageOfGameMessages.gameMessages.length; i++) {
      const jsonGameMessage: JsonGameMessage = jsonPageOfGameMessages.gameMessages[i];
      if (jsonGameMessage.text === undefined || jsonGameMessage.count === undefined) {
        return null;
      }
      if (jsonGameMessage.count > 1) {
        gameMessages.push(`${jsonGameMessage.text} (x${jsonGameMessage.count})`);
      } else {
        gameMessages.push(jsonGameMessage.text);
      }
    }

    return new PageOfGameMessages(jsonPageOfGameMessages.firstIndex, jsonPageOfGameMessages.lastIndex, gameMessages);
  }

  private isFullyVisible(tableRow: HTMLTableRowElement) {
    const tableRowClientRect = tableRow.getBoundingClientRect();
    const windowRect = this.scrollDivRef?.nativeElement.getBoundingClientRect();

    const isVisible = (tableRowClientRect.top >= 0) && (tableRowClientRect.bottom <= windowRect!.height);

    return isVisible;
  }

  private isPartiallyVisible(tableRow: HTMLTableRowElement) {
    var tableRowClientRect = tableRow.getBoundingClientRect();
    const windowRect = this.scrollDivRef?.nativeElement.getBoundingClientRect();

    const isVisible = tableRowClientRect.top < windowRect!.height && tableRowClientRect.bottom >= 0;
    return isVisible;
  }

  /** Brings the most recent message into view. */
  private bringMostRecentMessageIntoView() {
    // Bring the last table row into view.  This needs to be done via a timer, to allow Angular to update the list and create any new table rows
    // subsequent to any messages we just added.
    setTimeout(() => {
      const lastRow = this.tableRows.last;
      lastRow?.nativeElement.scrollIntoView({ block: 'center', behavior: 'smooth' });
    });
  }

  private requestMoreMessagesForFillMode() {
    // We need to set a timer for this action to be done, to allow Angular to update the list and create any new table rows subsequent to any messages
    // we just added.
    setTimeout(() => {
      if (this.fillMode) {
        // Check to see if we have all of the possible messages.
        if (this.masterPageOfGameMessages != null && this.masterPageOfGameMessages.lastIndex === 0) {
          // There are no more messages that we can request.
          this.fillMode = false;
        } else {
          // Check to see if there is room for more messages in the scrollable area.
          const lastRow = this.tableRows.last;
          const lastRowClientRect = lastRow.nativeElement.getBoundingClientRect();
          const scrollDivRect = this.scrollDivRef!.nativeElement.getBoundingClientRect();
          const lastRowPartiallyOrFullyHidden = lastRowClientRect.bottom >= scrollDivRect.bottom;
          if (!lastRowPartiallyOrFullyHidden) {
            // Request more messages.
            this.requestEarlierMessages();
          }
        }
      }
    });
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
                // Check to see if we have any messages received from the game.
                if (jsonPageOfGameMessages != null) {
                  // Validate the JSON structure.
                  const pageOfGameMessages: PageOfGameMessages | null = this.validatePageOfGameMessages(jsonPageOfGameMessages);
                  if (pageOfGameMessages !== null) {
                    // Check to see if we have an existing page of messages to work with.
                    if (this.masterPageOfGameMessages === null) {
                      // This the initial load.
                      this.masterPageOfGameMessages = pageOfGameMessages;
                      this.bringMostRecentMessageIntoView();
                    } else {
                      // Here we will need to update the existing page of messages that we ave.  Check to see if the page should be appended to the end.
                      if (pageOfGameMessages.lastIndex === this.masterPageOfGameMessages.firstIndex) {
                        // There is no gap and the oldest message received replaces the most-recent message that we have.  We will need to replace the most-recent message and append the rest.
                        // Drop the most-recent message.
                        this.masterPageOfGameMessages.gameMessages.pop();

                        // Now append the new messages.
                        this.masterPageOfGameMessages.gameMessages = this.masterPageOfGameMessages.gameMessages.concat(pageOfGameMessages.gameMessages!);

                        // Reset the index for the most-recent message.
                        this.masterPageOfGameMessages.firstIndex = pageOfGameMessages.firstIndex;
                        this.bringMostRecentMessageIntoView();
                      } else {
                        // Check to see if there is a gap.  If a gap occurs, we will discard the existing page and restart.  Normally, messages are requested to ensure
                        // there is no gap from the existing master list.  If this gap should does occur, then there messages that were deleted from the game--the log is too long.
                        // In this scenario, we have to assume all previous messages are also gone.  So we will discard the master list and show what we have.
                        if (pageOfGameMessages.lastIndex > this.masterPageOfGameMessages.firstIndex) {
                          // There is a gap.  Discard the master list.
                          this.masterPageOfGameMessages = pageOfGameMessages;
                          this.bringMostRecentMessageIntoView();
                        } else {
                          // Check to see if the page should be inserted at the beginning.
                          if (pageOfGameMessages.firstIndex + 1 === this.masterPageOfGameMessages.lastIndex) {
                            // There is no gap.  Concatenate the messages together.  This will be happening when the user is scrolling up.  With this process, we are not
                            // bringing the most-recent message into view.
                            this.masterPageOfGameMessages.gameMessages = pageOfGameMessages.gameMessages.concat(this.masterPageOfGameMessages.gameMessages);
                            this.masterPageOfGameMessages.lastIndex = pageOfGameMessages.lastIndex;
                          } else {
                            // There is a gap.  Something unexpected happened with the request and there is nothing we can do.  We do not want to
                            // have an incorrect list.  We will simply ignore the received page of messages.
                          }
                        }
                      }
                    }
                  }

                  // Detect if we are in fill mode and request more messages, if we are.
                  this.requestMoreMessagesForFillMode();
                } else {
                  this.fillMode = false;
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

    // We are turning on the fill mode so that we can request more messages in an attempt to fill the viewable area of the scroll window.
    this.fillMode = true;
    if (this.connection) {
      this.connection.send("MonitorGameMessages", this.gameConnectionId, 20);
    }
  }

  private requestEarlierMessages() {
    // Send a message to the hub to receive the current messages.  We can only do this, if the oldest message is greater than 0.
    if (this.connection && this.masterPageOfGameMessages !== null && this.masterPageOfGameMessages.lastIndex > 0) {
      // Request an update from the game.  We will also request the most-recent message that we already have.  This is to catch updates in counts (x1), (x2) etc.
      this.connection.send("GetGameMessages", this.gameConnectionId, this.masterPageOfGameMessages.lastIndex - 1, 0, null);
    }
  }

  public refresh() {
    // Send a message to the hub to receive the current messages.
    if (this.connection && this.masterPageOfGameMessages !== null) {
      // Request an update from the game.  We will also request the most-recent message that we already have.  This is to catch updates in counts (x1), (x2) etc.
      this.connection.send("GetGameMessages", this.gameConnectionId, null, this.masterPageOfGameMessages.firstIndex, null);
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
