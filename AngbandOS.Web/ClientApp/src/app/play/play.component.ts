import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { MatSnackBar } from '@angular/material/snack-bar';

export class PostNewGame {
  public username: string = "";
}

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
  public charSize: number | undefined;

  constructor(
    private _httpClient: HttpClient,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private _authorizeService: AuthorizeService,
    private _zone: NgZone
  ) {
  }

  //@HostListener('window:resize', ['$event'])
  //public onResize(event: any) {
  //  this._zone.run(() => {
  //    if (this.canvasRef !== undefined) {
  //      const canvas = this.canvasRef.nativeElement;
  //      var dpr = window.devicePixelRatio || 1;
  //      var rect = canvas.getBoundingClientRect();
  //    //  canvas.width = 80 * 18; // rect.width * dpr;
  //    //  canvas.height = 45 * 18; // rect.height * dpr;
  //    //  canvas.style.width = 80 * 18;
  //    //  canvas.style.height = 45 * 18;
  //    //  canvas.style.aspectRatio = 1;
  //    }
  //  });
  //}

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

//  private getObjectFitSize(
//    contains: boolean /* true = contain, false = cover */,
//    containerWidth: number,
//    containerHeight: number,
//    width : number,
//    height: number
//  ) {
//  var doRatio = width / height;
//  var cRatio = containerWidth / containerHeight;
//  var targetWidth = 0;
//  var targetHeight = 0;
//  var test = contains ? doRatio > cRatio : doRatio < cRatio;

//  if (test) {
//    targetWidth = containerWidth;
//    targetHeight = targetWidth / doRatio;
//  } else {
//    targetHeight = containerHeight;
//    targetWidth = targetHeight * doRatio;
//  }

//  return {
//    width: targetWidth,
//    height: targetHeight,
//    x: (containerWidth - targetWidth) / 2,
//    y: (containerHeight - targetHeight) / 2
//  };
//}

  check() {
    if (this.connection !== undefined && this.gameGuid !== undefined) {
      this.connection.start().then(() => {
        if (this.connection) {
          this.connectionId = this.connection.connectionId;

          this.connection.on("SetBackgroundCell", (row: number, col: number, color: string) => {
            this._zone.run(() => {
            });
          });
          this.connection.on("Clear", () => {
            this._zone.run(() => {
              if (this.canvasRef !== undefined) {
                const canvas = this.canvasRef.nativeElement;
                var dpr = window.devicePixelRatio || 1;
                var rect = canvas.getBoundingClientRect();
                //const dimensions = this.getObjectFitSize(
                //  true,
                //  canvas.clientWidth,
                //  canvas.clientHeight,
                //  canvas.width,
                //  canvas.height
                //);
                //canvas.width = dimensions.width;
                //canvas.height = dimensions.height;
                //canvas.width = 80 * 18; // rect.width * dpr;
                //canvas.height = 45 * 18; // rect.height * dpr;
                //canvas.style.width = 80 * 18;
                //canvas.style.height = 45 * 18;
                //canvas.style.aspectRatio = 1;
                const context: CanvasRenderingContext2D = canvas.getContext('2d');
                //context.scale(1, 1);
                context.clearRect(0, 0, rect.width, rect.height);
              }
            });
          });
          this.connection.on("Print", (row: number, col: number, text: string, color: string) => {
            this._zone.run(() => {
              if (this.canvasRef !== undefined) {
                const canvas = this.canvasRef.nativeElement;
                canvas.style.width = 1440;
                canvas.style.height = 810;
                const context: CanvasRenderingContext2D = canvas.getContext('2d');
                this.charSize = 18;
                context.clearRect(col * this.charSize, row * this.charSize, text.length * this.charSize, this.charSize);
                context.imageSmoothingEnabled = false;
                context.textBaseline = 'top';
                context.textAlign = 'left';
                context.fillStyle = `#${color.substring(3)}`; // Convert from RGBA to RGB
                context.font = `${this.charSize}px Courier`;
                for (var i: number = 0; i < text.length; i++) {
                  const c = text[i];
                  context.fillText(c, col * this.charSize, row * this.charSize);
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
    // Wait for authorization.
    this._initSubscriptions.add(this._authorizeService.getAccessToken().subscribe((_accessToken) => {
      // Ensure there is an access token and that the connection has been established already.
      if (_accessToken !== null && _accessToken !== undefined && this.connection == undefined) {
        // Create the signal-r connection object.
        this.connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/hub", { accessTokenFactory: () => _accessToken }).build();
        this.check();
      }
    }));

    // Retrieve the game guid from the query.
    this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap) => {
      this.gameGuid = paramMap.get("guid");
      this.check();
    }));
  }

  ngOnDestroy() {
    if (this.connection) {
      this.connection.off("SetBackgroundCell");
      this.connection.off("Clear");
      this.connection.off("Print");
      this.connection.off("SetBackground");
      this.connection.off("PlaySound");
      this.connection.off("PlayMusic");
      this._initSubscriptions.unsubscribe();
    }
  }
}
