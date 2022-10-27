import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActiveUserDetails } from './active-user-details';
import { HubConnections } from './HubConnections';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit, OnDestroy {
  private adminConnection: SignalR.HubConnection | undefined;
  public chatHubConnections: ActiveUserDetails[] | undefined = undefined;
  public adminHubConnections: ActiveUserDetails[] | undefined = undefined;
  public gameHubConnections: ActiveUserDetails[] | undefined = undefined;
  public serviceHubConnections: ActiveUserDetails[] | undefined = undefined;
  public spectatorsHubConnections: ActiveUserDetails[] | undefined = undefined;
  public isAuthenticated: boolean = false;
  public isAdministrator: boolean = false;
  private subscriptions = new Subscription();
  private _accessToken: string | undefined;
  public displayColumns: string[] = ["username", "connectionId", "dateTime"];

  constructor(
    private _authenticationService: AuthenticationService,
    private _ngZone: NgZone
  ) {
  }

  private reconnect() {
    if (this.adminConnection !== undefined) {
      this.adminConnection?.stop();
    }

    if (this._accessToken !== undefined) {
      this.adminConnection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/admin-hub", {
        accessTokenFactory: () => this._accessToken as string
      }).build();

      // Start a signal-r connection to receive updates to the list.
      this.adminConnection.start().then(() => {
        if (this.adminConnection !== undefined) {
          this.adminConnection.on("HubConnectionsUpdated", (_hubConnections: HubConnections) => {
            this._ngZone.run(() => {
              this.chatHubConnections = _hubConnections.chatHubConnections;
              this.adminHubConnections = _hubConnections.adminHubConnections;
              this.serviceHubConnections = _hubConnections.serviceHubConnections;
              this.gameHubConnections = _hubConnections.gameHubConnections;
              this.spectatorsHubConnections = _hubConnections.spectatorsHubConnections;
            })
          });
          this.adminConnection.send("UpdateHubConnections");
        }
      });
    }
  }

  ngOnInit() {
    this.subscriptions.add(this._authenticationService.currentUser.subscribe((_user: UserDetails | null) => {
      if (this._authenticationService.currentUser.value !== null) {
        this._accessToken = this._authenticationService.currentUser.value.jwt;
        this.reconnect();
      }
    }));
  }

  ngOnDestroy() {
    if (this.adminConnection !== undefined) {
      this.adminConnection.off("HubConnectionsUpdated");
      this.adminConnection.stop();
    }
  }
}
