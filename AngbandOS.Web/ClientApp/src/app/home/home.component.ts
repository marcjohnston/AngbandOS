import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, ViewChild } from '@angular/core';
import * as SignalR from "@microsoft/signalr";

export class PostNewGame {
  public username: string = "";
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: [
    './home.component.scss'
  ]
})
export class HomeComponent {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  public readonly connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/hub").build();
  public connectionId: string | null = null;
  public gameGuid: string | null = null;

  constructor(
    private _httpClient: HttpClient,
    private _zone: NgZone
  ) {
    const postNewGame: PostNewGame = {
      username: "marc"
    };
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
            const charSize = 12;
            context.clearRect(col * charSize, row * charSize, text.length * charSize, charSize);
            context.textBaseline = 'top';
            context.textAlign = 'left';
            context.fillStyle = `#${color.substring(3)}`; // Convert from RGBA to RGB
            context.font = `${charSize}px courier`;
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
        });
      });
      this.connection.on("PlayMusic", (music: number) => {
        this._zone.run(() => {
        });
      });

      //this.connection.send("play", "96454DEC-6B99-4840-9A79-F2914E7D2760"); //this.gameGuid
      this._httpClient.post<string>(`/apiv1/games`, postNewGame).toPromise().then((guid: string | undefined) => {
        if (guid !== undefined) {
          this.gameGuid = guid;
          this.connection.send("play", this.gameGuid);
        }
      }, (error: HttpErrorResponse) => {
        this.gameGuid = "post failed";
      });
    });
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
}
