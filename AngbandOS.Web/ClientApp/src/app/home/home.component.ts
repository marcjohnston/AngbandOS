import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Observable, Subscription } from 'rxjs';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { SavedGameDetails } from './saved-game-details';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../modules/error-messages/error-messages.module';
import { ActiveGameDetails } from './active-game-details';

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
export class HomeComponent implements OnInit, OnDestroy {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  public readonly serviceConnection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/service-hub").build();
  public savedGames: SavedGameDetails[] | undefined = undefined;
  public activeGames: ActiveGameDetails[] | undefined = undefined;
  public savedGamesDisplayedColumns: string[] = ["character-name", "gold", "level", "is-alive", "last-saved", "actions"];
  public activeGamesDisplayedColumns: string[] = ["username", "character-name", "gold", "level"];
  public selectedActiveGame: ActiveGameDetails | null = null;
  public selectedSavedGame: SavedGameDetails | null = null;
  public isAuthenticated: boolean = false;
  private _initSubscriptions = new Subscription();

  constructor(
    private _httpClient: HttpClient,
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService,
    private _router: Router,
    private _ngZone: NgZone
  ) {
  }

  ngOnInit() {
    // Start a signal-r connection to receive updates to the list.
    this.serviceConnection.start().then(() => {
      if (this.serviceConnection !== undefined) {
        this.serviceConnection.on("ActiveGamesUpdated", (_activeGames: ActiveGameDetails[]) => {
          this._ngZone.run(() => {
            this.activeGames = _activeGames;
          })
        });
        this.serviceConnection.send("Refresh");
      }
    });

    // Send a message to retrieve all of the active games.  This will force seed the list.
    //this._httpClient.get<ActiveGameDetails[]>(`/apiv1/games`).toPromise().then((_activeGames) => {
    //  this.activeGames = _activeGames;
    //}, (_errorResponse: HttpErrorResponse) => {
    //  this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
    //    duration: 5000
    //  });
    //});

    this._initSubscriptions.add(this._authenticationService.currentUser.subscribe((_userDetails: UserDetails | null) => {
      this.isAuthenticated = (_userDetails !== null && _userDetails.username !== null);

      if (this.isAuthenticated) {
        this._httpClient.get<SavedGameDetails[]>(`/apiv1/saved-games`).toPromise().then((_savedGames) => {
          this._ngZone.run(() => {
            this.savedGames = _savedGames;
          });
        }, (_errorResponse: HttpErrorResponse) => {
          this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
            duration: 5000
          });
        });
      } else {
        this._authenticationService.autoLogin();
      }
    }));
  }

  ngOnDestroy() {
    if (this.serviceConnection !== undefined) {
      this.serviceConnection.off("ActiveGamesUpdated");
      this.serviceConnection.stop();
    }
  }

  public onSavedGameRowClick(savedGame: SavedGameDetails) {
    this._router.navigate(['/play', savedGame.guid]);
  }

  public onActiveGameRowClick(activeGame: ActiveGameDetails) {
    this._router.navigate(['/watch', activeGame.connectionId]);
  }

  public onNewGame() {
    this._router.navigate(['/play']);
  }

  public deleteSavedGame(savedGame: SavedGameDetails) {
    this._httpClient.delete<SavedGameDetails[]>(`/apiv1/saved-games/${savedGame.guid}`).toPromise().then((_savedGames) => {
      this._ngZone.run(() => {
        this.savedGames = _savedGames;
      });
    }, (_errorResponse: HttpErrorResponse) => {
      this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
        duration: 5000
      });
    });
  }
}
