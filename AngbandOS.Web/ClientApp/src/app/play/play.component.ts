import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';

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
  public readonly connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/hub").build();
  public connectionId: string | null = null;
  public gameGuid: string | null = null;
  private _initSubscriptions = new Subscription();
  public charSize: number | undefined;

  constructor(
    private _httpClient: HttpClient,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _zone: NgZone
  ) {
  }

  @HostListener('window:keydown', ['$event'])
  public onKeyDown(event: KeyboardEvent) {
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
      case "Ctrl":
      case "Alt":
      case "Shift":
        break;
      default:
        this.connection.send("keypressed", event.key);
        break;
    }
  }

  ngOnInit() {
    this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap) => {
      // Retrieve the card-set id from the route.
      this.gameGuid = paramMap.get("guid");

      this.connection.start().then(() => {
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
              canvas.width = rect.width * dpr;
              canvas.height = rect.height * dpr;
              //canvas.style.width = canvas.width;
              //canvas.style.height = canvas.height;
              const context: CanvasRenderingContext2D = canvas.getContext('2d');
              context.clearRect(0, 0, rect.width, rect.height);
            }
          });
        });
        this.connection.on("Print", (row: number, col: number, text: string, color: string) => {
          this._zone.run(() => {
            if (this.canvasRef !== undefined) {
              const canvas = this.canvasRef.nativeElement;
              const context: CanvasRenderingContext2D = canvas.getContext('2d');
              var rect = canvas.getBoundingClientRect();
              this.charSize = 18;
              context.clearRect(col * this.charSize, row * this.charSize, text.length * this.charSize, this.charSize);
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
      });
    }));
  }

  ngOnDestroy() {
    this.connection.off("SetBackgroundCell");
    this.connection.off("Clear");
    this.connection.off("Print");
    this.connection.off("SetBackground");
    this.connection.off("PlaySound");
    this.connection.off("PlayMusic");
    this._initSubscriptions.unsubscribe();
  }
}
