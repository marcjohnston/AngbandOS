import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { Subscription, timer } from 'rxjs';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { SavedGameDetails } from './saved-game-details';
import { MatSnackBar as MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../modules/error-messages/error-messages.module';
import { ActiveGameDetails } from './active-game-details';
import { DatePipe, NgClass, NgIf } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { ChangeDetectorRef } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MasterLayoutComponent } from '../master-layout/master-layout.component';

const idleTimeSpanUpdateIntervalInMilliseconds = 1000;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    NgClass,
    MatIconModule,
    DatePipe,
    MatTableModule,
    MatButtonModule,
    MasterLayoutComponent
  ]
})
export class HomeComponent implements OnInit, OnDestroy {
  public savedGames: SavedGameDetails[] | undefined = undefined;
  public activeGames: ActiveGameDetails[] | undefined = undefined;
  public savedGamesDisplayedColumns: string[] = ["character-name", "gold", "level", "is-alive", "last-saved", "actions"];
  public activeGamesDisplayedColumns: string[] = ["username", "character-name", "gold", "level", "last-input-received", "game-time", "actions"];
  public activeUsersDisplayedColumns: string[] = ["username", "connectionId", "actions"];
  public selectedActiveUser: UserDetails | null = null;
  public selectedSavedGame: SavedGameDetails | null = null;

  private readonly _initSubscriptions = new Subscription();
  private readonly _serviceConnection = new HubConnectionBuilder().withUrl("/apiv1/service-hub").build();

  constructor(
    private _httpClient: HttpClient,
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService,
    private _router: Router,
    private _changeDetectorRef: ChangeDetectorRef
  ) {
  }

  public get isAuthenticated(): boolean {
    return this._authenticationService.isAuthenticated;
  }

  public get isAdministrator(): boolean {
    return this._authenticationService.isAdministrator;
  }

  public get username(): string | null {
    return this._authenticationService.username;
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

  private updateIdleTimeSpans() {
    if (this.activeGames !== undefined) {
      const millisecondsPerMinute = 1000 * 60;
      const millisecondsPerHour = millisecondsPerMinute * 60;
      for (let i = 0; i < this.activeGames.length; i++) {
        const activeGame = this.activeGames[i];
        if (activeGame.lastInputReceived !== undefined && activeGame.lastInputReceived !== null) {
          const lastInputReceived: number = Date.parse(activeGame.lastInputReceived);
          const idleTimeInMilliseconds: number = Date.now() - lastInputReceived;
          const hoursIdle = Math.floor(idleTimeInMilliseconds / millisecondsPerHour);
          const minutesAndSecondsOfIdleTimeRemainingInMilliseconds = idleTimeInMilliseconds % millisecondsPerHour;
          const minutesIdle = Math.floor(minutesAndSecondsOfIdleTimeRemainingInMilliseconds / millisecondsPerMinute);
          const secondsOfIdleTimeRemainingInMilliseconds = minutesAndSecondsOfIdleTimeRemainingInMilliseconds % millisecondsPerMinute;
          const secondsIdle = Math.floor(secondsOfIdleTimeRemainingInMilliseconds / 1000);
          activeGame.idleTimeSpan = this.timeSpanAsString(`${hoursIdle}:${minutesIdle}:${secondsIdle}`);
        }
      }
      this._changeDetectorRef.detectChanges();

      // Restart another timer for the next update.
      setTimeout(() => this.updateIdleTimeSpans(), idleTimeSpanUpdateIntervalInMilliseconds);
    }
  }

  ngOnInit() {
    // Start a signal-r connection to receive updates to the list.
    this._serviceConnection.start().then(() => {
      if (this._serviceConnection !== undefined) {
        this._serviceConnection.on("ActiveGamesUpdated", (_activeGames: ActiveGameDetails[]) => {
          this.activeGames = _activeGames;
          this._changeDetectorRef.detectChanges();
        });
        this._serviceConnection.send("RefreshActiveGames");
      }
    }, (reason: any) => {
      console.log(`Service hub rejected connection.  ${reason}`);
    });

    // Start a single timer that updates the idle timeouts.
    setTimeout(() => this.updateIdleTimeSpans(), idleTimeSpanUpdateIntervalInMilliseconds);

    // Subscribe to the authenticated user.
    const currentUserSubscription = this._authenticationService.currentUser.subscribe((_userDetails: UserDetails | null) => {
      if (_userDetails !== null && _userDetails.username !== null) {
        this._changeDetectorRef.detectChanges();
        this._httpClient.get<SavedGameDetails[]>(`/apiv1/saved-games`).toPromise().then((_savedGames) => {
          this.savedGames = _savedGames; 
          this._changeDetectorRef.detectChanges();
        }, (_errorResponse: HttpErrorResponse) => {
          this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
            duration: 5000
          });
        });
      }
    });

    // Track the subscription so that it can be unsubscribed.
    this._initSubscriptions.add(currentUserSubscription);
  }

  private showMessage(message: string) {
    this._snackBar.open(message, "", {
      duration: 5000
    });
    this._changeDetectorRef.detectChanges();
  }

  public killActiveGame(activeGame: ActiveGameDetails) {
    this._httpClient.delete(`/apiv1/games/${activeGame.connectionId}`).toPromise().then((_savedGames) => {
      this.showMessage("Game killed.");
    }, (_errorResponse: HttpErrorResponse) => {
      this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
        duration: 5000
      });
    });   
  }

  async ngOnDestroy() {
    if (this._serviceConnection !== undefined) {
      this._serviceConnection.off("ActiveGamesUpdated");
      await this._serviceConnection.stop();
    }
  }

  public playSavedGame(savedGame: SavedGameDetails) {
    this._router.navigate(['/play', savedGame.guid]);
  }

  public onActiveGameRowClick(activeGame: ActiveGameDetails) {
    this._router.navigate(['/watch', activeGame.connectionId]);
  }

  public replaySavedGame(savedGame: SavedGameDetails) {
    this._router.navigate(['/play', savedGame.guid], { queryParams: { replay: 1}});
  }
  
  public onNewGame() {
    this._router.navigate(['/play']);
  }

  public deleteSavedGame(savedGame: SavedGameDetails) {
    if (window.confirm('Are you sure you want to delete this game?')) {
      this._httpClient.delete<SavedGameDetails[]>(`/apiv1/saved-games/${savedGame.guid}`).toPromise().then((_savedGames) => {
        this.savedGames = _savedGames;
        this._changeDetectorRef.detectChanges();
      }, (_errorResponse: HttpErrorResponse) => {
        this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
          duration: 5000
        });
      });
    }
  }
}
