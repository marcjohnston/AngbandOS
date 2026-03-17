import { Component, ElementRef, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HtmlConsole } from '../modules/html-console/html-console.module';
import { PrintLine } from '../modules/html-console/print-line';
import { ConsoleConfiguration } from '../modules/html-console/console-configuration';
import { MasterLayoutComponent } from '../master-layout/master-layout.component';

@Component({
  selector: 'app-watch',
  templateUrl: './watch.component.html',
  styleUrls: ['./watch.component.scss'],
  standalone: true,
  imports: [
    MasterLayoutComponent
  ]
})
export class WatchComponent implements OnInit, OnDestroy {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  @ViewChild('canvasContainer', { static: true }) private canvasContainerRef: ElementRef | undefined;
  private spectatorHubConnection: HubConnection | undefined;
  public connectionId: string | null = null;
  public gameGuid: string | null | undefined = undefined; // Represents the unique identifier for the game to play; null, to start a new game; otherwise, undefined when the guid hasn't been retrieved yet.
  private _initSubscriptions = new Subscription();
  private _htmlConsole: HtmlConsole | undefined = undefined;
  private resizeObserver!: ResizeObserver;

  constructor(
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private _zone: NgZone
  ) {
  }

  ngOnInit() {
    if (this.canvasRef !== undefined) {
      this._htmlConsole = new HtmlConsole(this.canvasRef, new ConsoleConfiguration());
    }

    // Create the signal-r connection object.
    this.spectatorHubConnection = new HubConnectionBuilder().withUrl("/apiv1/spectators-hub").build();

    // Retrieve the game guid from the query.
    this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap: ParamMap) => {
      this.gameGuid = paramMap.get("guid");

      if (this.spectatorHubConnection !== undefined) {
        this.spectatorHubConnection.start().then(() => {
          if (this.spectatorHubConnection) {
            this.connectionId = this.spectatorHubConnection.connectionId; // This is needed to render on the screen.

            this.spectatorHubConnection.on("Clear", () => {
              this._zone.run(() => {
                this._htmlConsole?.clear();
              });
            });
            this.spectatorHubConnection.on("BatchPrint", (printLines: PrintLine[]) => {
              this._zone.run(() => {
                this._htmlConsole?.batchPrint(printLines);
              });
            });
            this.spectatorHubConnection.on("SetBackground", (backgroundImage: number) => {
              this._zone.run(() => {
              });
            });
            this.spectatorHubConnection.on("PlaySound", (sound: number) => {
              this._zone.run(() => {
                this._htmlConsole?.playSound(sound);
              });
            });
            this.spectatorHubConnection.on("PlayMusic", (music: number) => {
              this._zone.run(() => {
              });
            });
            this.spectatorHubConnection.on("GameOver", () => {
              this._router.navigate(['/']);
            });

            this.spectatorHubConnection.send("watch", this.gameGuid);
          }


          // Track sizing on the canvas container.
          this.resizeObserver = new ResizeObserver(entries => {
            // Refresh the canvas.  Set the configuration, to our designer configuration.  The html console module automatically detectes the change and refreshes.  The screen will be blank from the refresh.
            this._htmlConsole!.consoleConfiguration = new ConsoleConfiguration();

            this.spectatorHubConnection?.send("Refresh");
          });
          this.resizeObserver.observe(this.canvasContainerRef?.nativeElement);
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
    if (this.spectatorHubConnection) {
      this.spectatorHubConnection.off("Clear");
      this.spectatorHubConnection.off("BatchPrint");
      this.spectatorHubConnection.off("SetBackground");
      this.spectatorHubConnection.off("PlaySound");
      this.spectatorHubConnection.off("PlayMusic");
      this.spectatorHubConnection.off("GameOver");
      this.spectatorHubConnection.stop();
      this._initSubscriptions.unsubscribe();
    }
  }
}
