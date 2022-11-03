import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { HtmlConsole } from '../modules/html-console/html-console.module';
import { PrintLine } from '../modules/html-console/print-line';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: [
    './play.component.scss'
  ]
})
export class PlayComponent implements OnInit, OnDestroy {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  private connection: SignalR.HubConnection | undefined;
  public connectionId: string | null = null;
  public gameGuid: string | null | undefined = undefined; // Represents the unique identifier for the game to play; null, to start a new game; otherwise, undefined when the guid hasn't been retrieved yet.
  private _initSubscriptions = new Subscription();
  private _htmlConsole: HtmlConsole | undefined = undefined;
  private _accessToken: string | undefined = undefined;

  constructor(
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService,
    private _zone: NgZone
  ) {
  }

  @HostListener('window:keydown', ['$event'])
  public onKeyDown(event: KeyboardEvent) {
    if (document.activeElement !== null && document.activeElement.id !== "chat-box") {
      if (this.connection) {
        const shift: string = (event.shiftKey ? "." : "");
        switch (event.key) {
          case "ArrowLeft":
            this.connection.send("keypressed", `${shift}4`);
            break;
          case "ArrowRight":
            this.connection.send("keypressed", `${shift}6`);
            break;
          case "ArrowUp":
            this.connection.send("keypressed", `${shift}8`);
            break;
          case "ArrowDown":
            this.connection.send("keypressed", `${shift}2`);
            break;
          case "Home":
            this.connection.send("keypressed", `${shift}7`);
            break;
          case "End":
            this.connection.send("keypressed", `${shift}1`);
            break;
          case "PageUp":
            this.connection.send("keypressed", `${shift}9`);
            break;
          case "PageDown":
            this.connection.send("keypressed", `${shift}3`);
            break;
          case "Enter":
            this.connection.send("keypressed", '\x0D');
            break;
          case "Tab":
            this.connection.send("keypressed", '\x09');
            break;
          case "Escape":
            this.connection.send("keypressed", '\x1B');
            break;
          case "Backspace":
            this.connection.send("keypressed", '\x08');
            break;

          // The following keys are stubbed so that they do not emit undesired characters into the game.
          case "Control":
          case "Alt":
          case "Shift":
          case "Delete":
          case "Insert":
          case "F1":
          case "F2":
          case "F3":
          case "F4":
          case "F5":
          case "F6":
          case "F7":
          case "F8":
          case "F9":
          case "F10":
          case "F11":
          case "F12":
            break;
          default:
            this.connection.send("keypressed", event.key);
            break;
        }
      }
    }
  }

  private check() {
    if (this.connection !== undefined && this.gameGuid !== undefined) {
      this.connection.start().then(() => {
        if (this.connection) {
          this.connectionId = this.connection.connectionId;

          this.connection.on("Clear", () => {
            this._zone.run(() => {
              this._htmlConsole?.clear();
            });
          });
          this.connection.on("BatchPrint", (printLines: PrintLine[]) => {
            this._zone.run(() => {
              this._htmlConsole?.batchPrint(printLines);
            });
          });
          this.connection.on("SetBackground", (backgroundImage: number) => {
            this._zone.run(() => {
            });
          });
          this.connection.on("SendMessage", (message: string) => {
            this._zone.run(() => {
              this._snackBar.open(message, undefined, {
                duration: 2000,
              });
            });
          });
          this.connection.on("GameIncompatible", () => {
            this._zone.run(() => {
              const snackBarRef = this._snackBar.open("Game cannot be played because it is incompatible.", undefined, {
                duration: 2000,                
              });
              this._initSubscriptions.add(snackBarRef.afterDismissed().subscribe(() => {
                this._router.navigate(['/']);
              }));
            });
          });
          this.connection.on("PlaySound", (sound: number) => {
            this._zone.run(() => {
              this._htmlConsole?.playSound(sound);
            });
          });
          this.connection.on("PlayMusic", (music: number) => {
            this._zone.run(() => {
            });
          });
          this.connection.on("GameOver", () => {
            this._router.navigate(['/']);
          });

          this.connection.send("play", this.gameGuid);
        }
      }, () => {
        this._snackBar.open("Connection to game server failed.", undefined, {
          duration: 2000,
        });
        this._router.navigate(['/']);
      });
    }
  }

  ngOnInit() {
    // Ensure the canvas element is available.
    if (this.canvasRef === undefined) {
      // If there is no canvas defined, log an error.
      console.log("Cannot play game.  Canvas missing!");
      this._router.navigate(['/']);
    } else {
      // Create an HTML console module to handle all of the interaction.
      this._htmlConsole = new HtmlConsole(this.canvasRef);

      // Wait for the authentication.  Games can only be played with authenticated.
      this._initSubscriptions.add(this._authenticationService.currentUser.subscribe((_currentUser: UserDetails | null) => {
        if (_currentUser === null) {
          this._accessToken = undefined;
        } else {
          // Get the access token for this user.  We need it for the signal-r hub authorization.
          this._accessToken = _currentUser.jwt;
        }

        if (this.connection !== undefined) {
          this.connection.stop();
        }

        // Ensure there is an access token and that the connection has been established already.
        if (this._accessToken !== undefined) {
          // Create the signal-r connection object.
          this.connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/game-hub", {
            accessTokenFactory: () => this._accessToken as string,
          }).build();
          this.check();
        }

        // Grab a copy of the users preferences.
      }));

      // Retrieve the game guid from the query.
      this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap) => {
        this.gameGuid = paramMap.get("guid");
        this.check();
      }));
    }
  }

  ngOnDestroy() {
    if (this.connection) {
      this.connection.off("Clear");
      this.connection.off("BatchPrint");
      this.connection.off("SetBackground");
      this.connection.off("PlaySound");
      this.connection.off("PlayMusic");
      this.connection.off("GameOver");
      this.connection.off("SendMessage");
      this.connection.off("GameIncompatible");
      this.connection.stop();
      this._initSubscriptions.unsubscribe();
    }
  }
}
