import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Observable, Subscription, timer } from 'rxjs';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { SavedGameDetails } from './saved-game-details';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../modules/error-messages/error-messages.module';
import { ActiveGameDetails } from './active-game-details';

const idleTimeIntervalInMilliseconds = 5000;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: [
    './home.component.scss'
  ]
})
export class HomeComponent implements OnInit, OnDestroy {
  private readonly serviceConnection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/service-hub").build();
  public savedGames: SavedGameDetails[] | undefined = undefined;
  public activeGames: ActiveGameDetails[] | undefined = undefined;
  public savedGamesDisplayedColumns: string[] = ["character-name", "gold", "level", "is-alive", "last-saved", "actions"];
  public activeGamesDisplayedColumns: string[] = ["username", "character-name", "gold", "level", "last-input-received", "game-time", "actions"];
  public activeUsersDisplayedColumns: string[] = ["username", "connectionId", "actions"];
  public selectedActiveGame: ActiveGameDetails | null = null;
  public selectedActiveUser: UserDetails | null = null;
  public selectedSavedGame: SavedGameDetails | null = null;
  public isAuthenticated: boolean = false;
  private _initSubscriptions = new Subscription();
  public isAdministrator: boolean = false;

  constructor(
    private _httpClient: HttpClient,
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService,
    private _router: Router,
    private _ngZone: NgZone
  ) {
  }

  private pluralize(value: number, singular: string, plural: string): string {
    if (value === 1) {
      return `${value} ${singular}`;
    } else {
      return `${value} ${plural}`;
    }
  }

  private join(s: string[]): string {
    let returnValue: string = "";
    let delimiter = "";
    for (let i: number = 0; i < s.length; i++) {
      if (s[i].length > 0) {
        returnValue = `${returnValue}${delimiter}${s[i]}`;
        delimiter = " ";
      }
    }
    return returnValue;
  }

  private pluralizeMonths(months: number): string {
    return this.pluralize(months, "month", "months");
  }

  private pluralizeDays(days: number): string {
    return this.pluralize(days, "day", "days");
  }

  private pluralizeHours(hours: number): string {
    return this.pluralize(hours, "hour", "hours");
  }

  private pluralizeMinutes(minutes: number): string {
    return this.pluralize(minutes, "minute", "minutes");
  }

  private pluralizeSeconds(seconds: number): string {
    return this.pluralize(seconds, "second", "seconds");
  }

  public timeSpanAsString(timeSpan: string): string {
    if (timeSpan === null || timeSpan === "") {
      return "0 seconds";
    }

    const periodTokens: string[] = timeSpan.split('.');
    const hoursMinutesSeconds: string = periodTokens[0];
    const hoursMinutesSecondTokens: string[] = hoursMinutesSeconds.split(':');
    const hoursAsString: string = hoursMinutesSecondTokens[0];
    const minutesAsString: string = hoursMinutesSecondTokens[1];
    const secondsAsString: string = hoursMinutesSecondTokens[2];
    const hours: number = parseInt(hoursAsString);
    const minutes: number = parseInt(minutesAsString);
    const seconds: number = parseInt(secondsAsString);
    let yearsTimeSpan: string = "";
    let monthsTimeSpan: string = "";
    let daysTimeSpan: string = "";
    let hoursTimeSpan: string = "";
    let minutesTimeSpan: string = "";
    let secondsTimeSpan: string = "";

    if (hours > 24) {
      const days = Math.trunc(hours / 24);
      hoursTimeSpan = this.pluralizeHours(hours % 24);

      if (days > 30) {
        const months = Math.trunc(days / 30);
        daysTimeSpan = this.pluralizeDays(days % 30);

        if (months > 12) {
          // Show just years and months.
          yearsTimeSpan = this.pluralize(months / 12, "year", "years");
          monthsTimeSpan = this.pluralizeMonths(months % 12);
          daysTimeSpan = ""; // Do not show days.
          hoursTimeSpan = ""; // Do not show hours.
        } else {
          // Show just months and days.
          monthsTimeSpan = this.pluralizeMonths(months);
          hoursTimeSpan = ""; // Do not show hours.
        }
      } else {
        // Show just days and hours.
        daysTimeSpan = this.pluralizeDays(days);
      }
    } else if (hours > 0) {
      // Show just hours and minutes.
      hoursTimeSpan = this.pluralizeHours(hours);
      minutesTimeSpan = this.pluralizeMinutes(minutes);
    } else {
      if (minutes > 0) {
        // Show just minutes and seconds.
        minutesTimeSpan = this.pluralizeMinutes(minutes);
        secondsTimeSpan = this.pluralizeSeconds(seconds);
      } else {
        // Show just seconds.
        secondsTimeSpan = this.pluralizeSeconds(seconds);
      }
    }
    return this.join([ yearsTimeSpan, monthsTimeSpan, daysTimeSpan, hoursTimeSpan, minutesTimeSpan, secondsTimeSpan ]);
  }

  private updateIdleTimes() {
    if (this.activeGames !== undefined) {
      for (let i = 0; i < this.activeGames.length; i++) {
        const activeGame = this.activeGames[i];
        if (activeGame.lastInputReceived !== undefined && activeGame.lastInputReceived !== null) {
          const lastInputReceived: number = Date.parse(activeGame.lastInputReceived);
          const idleTimeInMilliseconds: number = Date.now() - lastInputReceived;
          const hoursIdle = Math.trunc(idleTimeInMilliseconds / (1000 * 60 * 60));
          const minutesIdle = Math.trunc(idleTimeInMilliseconds / (1000 * 60));
          const secondsIdle = Math.trunc(idleTimeInMilliseconds / 1000);
          activeGame.idleTimeSpan = this.timeSpanAsString(`${hoursIdle}:${minutesIdle}:${secondsIdle}`);
        }
      }
      setTimeout(() => this.updateIdleTimes(), idleTimeIntervalInMilliseconds);
    }
  }

  ngOnInit() {
    // Start a signal-r connection to receive updates to the list.
    this.serviceConnection.start().then(() => {
      if (this.serviceConnection !== undefined) {
        this.serviceConnection.on("ActiveGamesUpdated", (_activeGames: ActiveGameDetails[]) => {
          this._ngZone.run(() => {
            this.activeGames = _activeGames;
            if (this.activeGames.length > 0) {
              setTimeout(() => this.updateIdleTimes(), idleTimeIntervalInMilliseconds);
            }
          })
        });
        this.serviceConnection.send("RefreshActiveGames");
      }
    });

    this._initSubscriptions.add(this._authenticationService.currentUser.subscribe((_userDetails: UserDetails | null) => {
      if (_userDetails !== null && _userDetails.username !== null) {
        this.isAuthenticated = true;
        this.isAdministrator = (_userDetails.isAdmin === true);
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
        this.isAuthenticated = false;
        this._authenticationService.autoLogin();
      }
    }));
  }

  public killActiveGame(activeGame: ActiveGameDetails) {
    this._httpClient.delete(`/apiv1/games/${activeGame.connectionId}`).toPromise().then((_savedGames) => {
      this._ngZone.run(() => {
        this._snackBar.open("Game killed.", "", {
          duration: 5000
        });
      });
    }, (_errorResponse: HttpErrorResponse) => {
      this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
        duration: 5000
      });
    });   
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
