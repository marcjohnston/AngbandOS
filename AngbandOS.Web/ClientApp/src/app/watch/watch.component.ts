import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { MatLegacySnackBar as MatSnackBar } from '@angular/material/legacy-snack-bar';
import { HtmlConsole } from '../modules/html-console/html-console.module';
import { ColorEnum } from '../modules/color-enum/color-enum.module';
import { PrintLine } from '../modules/html-console/print-line';

@Component({
  selector: 'app-watch',
  templateUrl: './watch.component.html',
  styleUrls: [
    './watch.component.scss'
  ]
})
export class WatchComponent implements OnInit, OnDestroy {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  private connection: SignalR.HubConnection | undefined;
  public connectionId: string | null = null;
  public gameGuid: string | null | undefined = undefined; // Represents the unique identifier for the game to play; null, to start a new game; otherwise, undefined when the guid hasn't been retrieved yet.
  private _initSubscriptions = new Subscription();
  private _htmlConsole: HtmlConsole | undefined = undefined;

  constructor(
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private _zone: NgZone
  ) {
  }

  ngOnInit() {
    if (this.canvasRef !== undefined) {
      this._htmlConsole = new HtmlConsole(this.canvasRef);
    }

    // Create the signal-r connection object.
    this.connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/spectators-hub").build();

    // Retrieve the game guid from the query.
    this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap: ParamMap) => {
      this.gameGuid = paramMap.get("guid");

      if (this.connection !== undefined) {
        this.connection.start().then(() => {
          if (this.connection) {
            this.connectionId = this.connection.connectionId; // This is needed to render on the screen.

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

            this.connection.send("watch", this.gameGuid);
          }
        }, () => {
          this._snackBar.open("Connection to game server failed.", undefined, {
            duration: 2000,
          });
          this._router.navigate(['/']);
        });
      }
    }));
  }

  ngOnDestroy() {
    if (this.connection) {
      this.connection.off("Clear");
      this.connection.off("BatchPrint");
      this.connection.off("SetBackground");
      this.connection.off("PlaySound");
      this.connection.off("PlayMusic");
      this.connection.off("GameOver");
      this.connection.stop();
      this._initSubscriptions.unsubscribe();
    }
  }
}
