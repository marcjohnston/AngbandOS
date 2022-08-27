import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { ColourEnum } from '../modules/colour-enum/colour-enum.module';
import { SoundEffectsEnum } from '../modules/sound-effects-enum/sound-effects-enum.module';
import { ColoursMap } from '../modules/colours-map/colours-map.module';
import { SoundEffectsMap } from '../modules/sound-effects-map/sound-effects-map.module';

const charSize = 12;

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
  private _sounds = SoundEffectsMap.getSoundEffectsMap();
  private _colours = ColoursMap.getColoursMap();

  constructor(
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
        case "Control":
        case "Alt":
        case "Shift":
          break;
        default:
          this.connection.send("keypressed", event.key);
          break;
      }
    }
  }

  public get charSize(): number {
    return charSize;
  }

  private updateCanvasSize() {
    if (this.canvasRef) {
      const canvas: HTMLCanvasElement = this.canvasRef.nativeElement;
      canvas.width = 80 * charSize;
      canvas.height = 45 * charSize;
      canvas.style.minWidth = canvas.width + "px";
      canvas.style.maxWidth = canvas.width + "px";
      canvas.style.minHeight = canvas.height + "px";
      canvas.style.maxHeight = canvas.height + "px";
    }
  }

  private check() {
    if (this.connection !== undefined && this.gameGuid !== undefined) {
      this.connection.start().then(() => {
        if (this.connection) {
          this.connectionId = this.connection.connectionId;

          this.connection.on("SetCellBackground", (row: number, col: number, c: string, color: ColourEnum) => {
            this._zone.run(() => {
              if (this.canvasRef) {
                const canvas = this.canvasRef.nativeElement;
                const context: CanvasRenderingContext2D = canvas.getContext('2d');
                context.fillStyle = `#FF0000`; // Rd background
                context.fillRect(col * charSize, row * charSize, charSize, charSize);
                context.textBaseline = 'top';
                context.textAlign = 'left';
                const rgbColor = this._colours[color];
                context.fillStyle = `${rgbColor}`;
                context.font = `${charSize}px Courier`;
                context.fillText(c, col * charSize, row * charSize);
              }
            });
          });
          this.connection.on("UnsetCellBackground", (row: number, col: number, c: string, color: ColourEnum) => {
            this._zone.run(() => {
              if (this.canvasRef) {
                const canvas = this.canvasRef.nativeElement;
                const context: CanvasRenderingContext2D = canvas.getContext('2d');
                context.fillStyle = `#000000`; // Rd background
                context.fillRect(col * charSize, row * charSize, charSize, charSize);
                context.textBaseline = 'top';
                context.textAlign = 'left';
                const rgbColor = this._colours[color];
                context.fillStyle = `${rgbColor}`;
                context.font = `${charSize}px Courier`;
                context.fillText(c, col * charSize, row * charSize);
              }
            });
          });
          this.connection.on("Clear", () => {
            this._zone.run(() => {
              if (this.canvasRef !== undefined) {
                const canvas = this.canvasRef.nativeElement;
                var dpr = window.devicePixelRatio || 1;
                var rect = canvas.getBoundingClientRect();
                const context: CanvasRenderingContext2D = canvas.getContext('2d');
                context.clearRect(0, 0, rect.width, rect.height);
              }
            });
          });
          this.connection.on("Print", (row: number, col: number, text: string, color: ColourEnum) => {
            this._zone.run(() => {
              if (this.canvasRef !== undefined) {
                const canvas = this.canvasRef.nativeElement;
                canvas.style.width = 1440;
                canvas.style.height = 810;
                const context: CanvasRenderingContext2D = canvas.getContext('2d');
                context.clearRect(col * charSize, row * charSize, text.length * charSize, charSize);
                context.textBaseline = 'top';
                context.textAlign = 'left';
                const rgbColor = this._colours[color];
                context.fillStyle = `${rgbColor}`;
                context.font = `${charSize}px Courier`;
                for (var i: number = 0; i < text.length; i++) {
                  const c = text[i];
                  context.fillText(c, col * charSize, row * charSize);
                  col++;
                }
              }
            });
          });
          this.connection.on("SetBackground", (backgroundImage: number) => {
            this._zone.run(() => {
            });
          });
          this.connection.on("PlaySound", (sound: number) => {
            this._zone.run(() => {

              // Get the list of available sounds.
              const availableSounds: string[] | undefined = this._sounds[sound];

              // Ensure there are sounds available.
              if (availableSounds !== undefined) {
                const randomSelection = Math.floor(Math.random() * availableSounds.length);

                // Choose one.
                var soundResourceName = availableSounds[randomSelection];

                // Play it.
                const audio = new Audio();
                audio.src = `/assets/sounds/${soundResourceName}`;
                audio.load();
                audio.play();
              }
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
    // Wait for the authentication.  Games can only be played with authenticated.
    this._initSubscriptions.add(this._authenticationService.currentUser.subscribe((_currentUser: UserDetails | null) => {
      if (_currentUser !== null) {
        // Get the access token for this user.  We need it for the signal-r hub authorization.
        const accessToken = _currentUser.jwt;

        // Ensure there is an access token and that the connection has been established already.
        if (accessToken !== null && accessToken !== undefined && this.connection == undefined) {
          // Create the signal-r connection object.
          this.connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/game-hub", {
            accessTokenFactory: () => accessToken,
          }).build();
          this.check();
        }
      }
    }));

    // Retrieve the game guid from the query.
    this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap) => {
      this.gameGuid = paramMap.get("guid");
      this.check();
    }));

    this.updateCanvasSize();
  }

  ngOnDestroy() {
    if (this.connection) {
      this.connection.off("UnsetCellBackground");
      this.connection.off("SetCellBackground");
      this.connection.off("Clear");
      this.connection.off("Print");
      this.connection.off("SetBackground");
      this.connection.off("PlaySound");
      this.connection.off("PlayMusic");
      this.connection.off("GameOver");
      this.connection.stop();
      this._initSubscriptions.unsubscribe();
    }
  }
}
