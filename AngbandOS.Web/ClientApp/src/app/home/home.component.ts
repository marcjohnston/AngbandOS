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
  public readonly connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/hub").build();
  public savedGames: SavedGameDetails[] | undefined = undefined;
  public displayedColumns: string[] = ["character-name", "gold", "level", "is-alive", "last-saved", "notes"];
  public selectedSavedGame: SavedGameDetails | null = null;
  public isAuthenticated: boolean = false;
  private _initSubscriptions = new Subscription();

  constructor(
    private _httpClient: HttpClient,
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService,
    private _router: Router
  ) {
  }

  ngOnInit() {
    this._initSubscriptions.add(this._authenticationService.currentUser.subscribe((_userDetails: UserDetails | null) => {
      this.isAuthenticated = (_userDetails !== null && _userDetails.username !== null);

      if (this.isAuthenticated) {
        this._httpClient.get<SavedGameDetails[]>(`/apiv1/games`).toPromise().then((_savedGames) => {
          this.savedGames = _savedGames;
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

  }

  public onRowClick(savedGame: SavedGameDetails) {
    this._router.navigate(['/play', savedGame.guid]);
  }

  public onNewGame() {
    this._router.navigate(['/play']);
  }
}
