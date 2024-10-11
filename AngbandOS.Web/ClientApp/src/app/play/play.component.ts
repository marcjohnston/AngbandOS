import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { HtmlConsole } from '../modules/html-console/html-console.module';
import { PrintLine } from '../modules/html-console/print-line';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { GetUserPreferences } from './get-user-preferences';
import { ErrorMessages } from '../modules/error-messages/error-messages.module';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { PreferencesDialogComponent } from '../preferences-dialog/preferences-dialog.component';
import { PreferencesDialogData } from '../preferences-dialog/preferences-dialog-data';
import { Preferences } from './preferences';
import { GameConfiguration } from "./game-configuration";
import { PutUserPreferences } from './put-user-preferences';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: [
    './play.component.scss'
  ]
})
export class PlayComponent implements OnInit, OnDestroy {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  @ViewChild('inGameMenu', { static: true }) private inGameMenuRef: ElementRef | undefined;
  private connection: SignalR.HubConnection | undefined;
  public connectionId: string | null = null;
  public gameGuid: string | null | undefined = undefined; // Represents the unique identifier for the game to play; null, to start a new game; otherwise, undefined when the guid hasn't been retrieved yet.
  private _initSubscriptions = new Subscription();
  private _htmlConsole: HtmlConsole | undefined = undefined;
  private _accessToken: string | undefined = undefined;
  public preferences: Preferences | undefined = undefined; // Represents the users preferences.  Will be undefined, until they are retrieved from the back end.

  constructor(
    private _preferencesDialog: MatDialog,
    private _httpClient: HttpClient,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService,
    private _zone: NgZone
  ) {
  }

  @HostListener('window:keydown', ['$event'])
  public onKeyDown(event: KeyboardEvent) {
    // Only accept keyboard input for the game, when the active element is the BODY.  Otherwise, input type controls on the screen need to process
    // the input.  We cannot limit the host listener because the other elements still belong to the body.
    if (document.activeElement !== null && document.activeElement.tagName.toUpperCase() === "BODY") {
      if (this.connection) {
        const shift: string = (event.shiftKey ? "." : "");
        switch (event.key) {
          case "ArrowLeft":
            this.connection.send("keypressed", `${shift}4`);
            event.preventDefault();
            break;
          case "ArrowRight":
            this.connection.send("keypressed", `${shift}6`);
            event.preventDefault();
            break;
          case "ArrowUp":
            this.connection.send("keypressed", `${shift}8`);
            event.preventDefault();
            break;
          case "ArrowDown":
            this.connection.send("keypressed", `${shift}2`);
            event.preventDefault();
            break;
          case "Home":
            this.connection.send("keypressed", `${shift}7`);
            event.preventDefault();
            break;
          case "End":
            this.connection.send("keypressed", `${shift}1`);
            event.preventDefault();
            break;
          case "PageUp":
            this.connection.send("keypressed", `${shift}9`);
            event.preventDefault();
            break;
          case "PageDown":
            this.connection.send("keypressed", `${shift}3`);
            event.preventDefault();
            break;
          case "Enter":
            this.connection.send("keypressed", '\x0D');
            event.preventDefault();
            break;
          case "Tab":
            this.connection.send("keypressed", '\x09');
            event.preventDefault();
            break;
          case "Escape":
            this.connection.send("keypressed", '\x1B');
            event.preventDefault();
            break;
          case "Backspace":
            this.connection.send("keypressed", '\x08');
            event.preventDefault();
            break;

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
            if (event.altKey) {
              this.macroClicked(event.key);
            }
            break;

          default:
            // Do not send special keystrokes.
            if (event.key.length === 1) {
              this.connection.send("keypressed", event.key);
            }
            break;
        }
      }
    }
  }

  public macroClicked(key: string) {
    if (this.connection !== undefined && this.preferences !== undefined) {
      let macro: string | null = null; // We use null, if there is no setting.
      switch (key) {
        case "F1":
          macro = this.preferences.f1Macro;
          break;
        case "F2":
          macro = this.preferences.f2Macro;
          break;
        case "F3":
          macro = this.preferences.f3Macro;
          break;
        case "F4":
          macro = this.preferences.f4Macro;
          break;
        case "F5":
          macro = this.preferences.f5Macro;
          break;
        case "F6":
          macro = this.preferences.f6Macro;
          break;
        case "F7":
          macro = this.preferences.f7Macro;
          break;
        case "F8":
          macro = this.preferences.f8Macro;
          break;
        case "F9":
          macro = this.preferences.f9Macro;
          break;
        case "F10":
          macro = this.preferences.f10Macro;
          break;
        case "F11":
          macro = this.preferences.f11Macro;
          break;
        case "F12":
          macro = this.preferences.f12Macro;
          break;
      }

      if (macro !== null) {
        do {
          const index: number = macro.indexOf("\\x");
          if (index === -1) {
            break;
          }
          const hex = macro.substring(index + 2, index + 4);
          let charCode = "";
          if (hex.length == 2) {
            const decimal = parseInt(hex, 16);
            if (!isNaN(decimal)) {
              charCode = String.fromCharCode(decimal);
            }
          }
          macro = `${macro?.substring(0, index)}${charCode}${macro.substring(index + 4)}`;
        } while (true);
      }
      this.connection.send("keypressed", macro);
    }
  }

  public onEditPreferencesClick() {
    // We cannot edit preferences, if they haven't been retrieved yet.
    if (this.preferences !== undefined) {
      // Generate the data to send to the dialog box.
      const dialogData: PreferencesDialogData = {
        fontName: this.preferences.fontName,
        fontSize: this.preferences.fontSize,
        f1Macro: this.preferences.f1Macro,
        f2Macro: this.preferences.f2Macro,
        f3Macro: this.preferences.f3Macro,
        f4Macro: this.preferences.f4Macro,
        f5Macro: this.preferences.f5Macro,
        f6Macro: this.preferences.f6Macro,
        f7Macro: this.preferences.f7Macro,
        f8Macro: this.preferences.f8Macro,
        f9Macro: this.preferences.f9Macro,
        f10Macro: this.preferences.f10Macro,
        f11Macro: this.preferences.f11Macro,
        f12Macro: this.preferences.f12Macro,
      };

      // Open the dialog box.
      const matDialogRef: MatDialogRef<PreferencesDialogComponent> = this._preferencesDialog.open(PreferencesDialogComponent, {
        height: '490px',
        width: '475px',
        data: dialogData
      });

      // Generate a hook when the dialog box closes so that we can retrieve the return data.
      const dialogSubscription = new Subscription();
      dialogSubscription.add(matDialogRef.afterClosed().subscribe((preferencesDialogData: PreferencesDialogData) => {
        dialogSubscription.unsubscribe();

        if (this.connection === undefined) {
          this.showSnackBar("Connection lost!")
        } else {
          this.updateUserPreferences(preferencesDialogData);
        }
      }));
    }
  }

  /**
   * When preferences are retrieved, update the local preferences.
   * @param getUserPreferences
   */
  private setUserPreferences(getUserPreferences: GetUserPreferences | undefined) {
    // Ensure the returned data is valid.
    if (getUserPreferences !== undefined &&
      getUserPreferences.fontName !== undefined &&
      getUserPreferences.fontSize !== undefined &&
      getUserPreferences.f1Macro !== undefined &&
      getUserPreferences.f2Macro !== undefined &&
      getUserPreferences.f3Macro !== undefined &&
      getUserPreferences.f4Macro !== undefined &&
      getUserPreferences.f5Macro !== undefined &&
      getUserPreferences.f6Macro !== undefined &&
      getUserPreferences.f7Macro !== undefined &&
      getUserPreferences.f8Macro !== undefined &&
      getUserPreferences.f9Macro !== undefined &&
      getUserPreferences.f10Macro !== undefined &&
      getUserPreferences.f11Macro !== undefined &&
      getUserPreferences.f12Macro !== undefined) {
      // Transfer the properties into the local storage.
      this.preferences = {
        fontName: getUserPreferences!.fontName!,
        fontSize: getUserPreferences!.fontSize!,
        f1Macro: getUserPreferences!.f1Macro!,
        f2Macro: getUserPreferences!.f2Macro!,
        f3Macro: getUserPreferences!.f3Macro!,
        f4Macro: getUserPreferences!.f4Macro!,
        f5Macro: getUserPreferences!.f5Macro!,
        f6Macro: getUserPreferences!.f6Macro!,
        f7Macro: getUserPreferences!.f7Macro!,
        f8Macro: getUserPreferences!.f8Macro!,
        f9Macro: getUserPreferences!.f9Macro!,
        f10Macro: getUserPreferences!.f10Macro!,
        f11Macro: getUserPreferences!.f11Macro!,
        f12Macro: getUserPreferences!.f12Macro!
      };
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
              this.showSnackBar(message);
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
            this._zone.run(() => {
              this.GameInProgress = false;
              this._router.navigate(['/']);
            });
          });
          this.connection.on("GameStarted", (gameGuid: string) => {
            this._zone.run(() => {
              this.gameGuid = gameGuid;
            });
          });

          this.GameInProgress = true;
          if (this.gameGuid === null) {
            const gameConfiguration: GameConfiguration = {
              maxMessageLogLength: 1,
              startupTownName: null,
              towns: null,
              shopkeepers: null,
              gameCommands: null,
              storeCommands: null,
              helpGroups: null,
              monsterRaces: null,
              symbols: null,
              vaults: null,
              dungeonGuardians: null,
              dungeons: null,
              storeFactories: null,
              projectileGraphics: null,
              amuletReadableFlavor: null,
              mushroomReadableFlavors: null,
              potionReadableFlavors: null,
              ringReadableFlavors: null,
              rodReadableFlavors: null,
              scrollReadableFlavors: null,
              staffReadableFlavors: null,
              wandReadableFlavors: null,
              classSpells: null,
              wizardCommands: null,
              tiles: null,
              animations: null,
              spells: null,
              plurals: null,
              attacks: null,
              gods: null,
              elvishTexts: null,
              findQuests: null,
              funnyComments: null,
              funnyDescriptions: null,
              horrificDescriptions: null,
              insultPlayerAttacks: null,
              moanPlayerAttacks: null,
              unreadableFlavorSyllables: null,
              shopkeeperAcceptedComments: null,
              shopkeeperBargainComments: null,
              shopkeeperGoodComments: null,
              shopkeeperLessThanGuessComments: null,
              shopkeeperWorthlessComments: null,
              singingPlayerAttacks: null,
              worshipPlayerAttacks: null
            }
            this.connection.send("PlayNewGame", gameConfiguration);
          } else {
            this.connection.send("PlayExistingGame", this.gameGuid);
          }
        }
      }, () => {
        this.showSnackBar("Connection to game server failed.");
        this._router.navigate(['/']);
      });
    }
  }

  public showDropDown() {
    this._zone.run(() => {
      const inGameMenuElement: HTMLDivElement = this.inGameMenuRef?.nativeElement;
      if (inGameMenuElement.style.display === "none") {
        inGameMenuElement.style.display = "block";
      } else {
        inGameMenuElement.style.display = "none";
      }
    });
  }

  /*
   * Returns true, if the game is still in progress; false, otherwise.  This is used for the can-deactivate-play component to throw a warning dialog box,
   * if the game is still in-progress. 
   */
  public GameInProgress: boolean = false;

  private showSnackBar(message: string) {
    this._snackBar.open(message, undefined, {
      duration: 2000,
    });
  }

  public openMessagesWindow() {
    window.open(`/watch/${this.connectionId}/messages`, "AngbandOS Messages", `height=${window.outerHeight},width=400`);
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

      // Setup the in-game drop-down menu.
      const inGameMenuElement: HTMLDivElement = this.inGameMenuRef?.nativeElement;
      inGameMenuElement.style.display = "none";
      
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

        this.getUserPreferences();
      }));

      // Retrieve the game guid from the query.
      this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap) => {
        // Retrieve the guid for the game to play.  If this is a new game, gameGuid will be returned as null.
        this.gameGuid = paramMap.get("guid");
        this.check();
      }));
    }
  }

  private updateUserPreferences(preferencesDialogData: PreferencesDialogData) {
    // Construct the data structure to send.
    const putUserPreferences: PutUserPreferences = {
      fontName: preferencesDialogData.fontName,
      fontSize: preferencesDialogData.fontSize,
      f1Macro: preferencesDialogData.f1Macro,
      f2Macro: preferencesDialogData.f2Macro,
      f3Macro: preferencesDialogData.f3Macro,
      f4Macro: preferencesDialogData.f4Macro,
      f5Macro: preferencesDialogData.f5Macro,
      f6Macro: preferencesDialogData.f6Macro,
      f7Macro: preferencesDialogData.f7Macro,
      f8Macro: preferencesDialogData.f8Macro,
      f9Macro: preferencesDialogData.f9Macro,
      f10Macro: preferencesDialogData.f10Macro,
      f11Macro: preferencesDialogData.f11Macro,
      f12Macro: preferencesDialogData.f12Macro
    };

    this._httpClient.put<GetUserPreferences>(`/apiv1/accounts/preferences`, putUserPreferences).toPromise().then((_getUserPreferences: GetUserPreferences | undefined) => {
      this._zone.run(() => {
        this.setUserPreferences(_getUserPreferences);
      });
    }, (_errorResponse: HttpErrorResponse) => {
      this.showSnackBar(ErrorMessages.getMessage(_errorResponse).join('\n'));
    });
  }

  private getUserPreferences() {
    this._httpClient.get<GetUserPreferences>(`/apiv1/accounts/preferences`).toPromise().then((_getUserPreferences: GetUserPreferences | undefined) => {
      this._zone.run(() => {
        this.setUserPreferences(_getUserPreferences);
      });
    }, (_errorResponse: HttpErrorResponse) => {
      this.showSnackBar(ErrorMessages.getMessage(_errorResponse).join('\n'));
    });
  }

  ngOnDestroy() {
    if (this.connection) {
      this.connection.off("Clear");
      this.connection.off("BatchPrint");
      this.connection.off("SetBackground");
      this.connection.off("PlaySound");
      this.connection.off("PlayMusic");
      this.connection.off("GameOver");
      this.connection.off("GameStarted");
      this.connection.off("SendMessage");
      this.connection.off("GameIncompatible");
      this.connection.stop();
      this._initSubscriptions.unsubscribe();
    }
  }
}
