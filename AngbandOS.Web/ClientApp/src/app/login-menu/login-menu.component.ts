import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { Subscription } from 'rxjs';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.scss'],
  standalone: true,
  imports: [
    RouterLink,
    MatButtonModule,
    NgIf
  ]
})
export class LoginMenuComponent implements OnInit, OnDestroy {
  constructor(
    private _authenticationService: AuthenticationService,
  ) { }

  public get isAuthenticated(): boolean {
    return this._authenticationService.isAuthenticated;
  }

  public get isAdministrator(): boolean {
    const userDetails: UserDetails | null = this._authenticationService.currentUser?.value;
    if (userDetails !== null) {
      return userDetails.isAdmin;
    }
    return false;
  }

  public get username(): string | null {
    const userDetails: UserDetails | null = this._authenticationService.currentUser?.value;
    if (userDetails !== null) {
      return userDetails.username;
    }
    return null;
  }
  ngOnInit() { }

  ngOnDestroy() { }

  public onWikiClick() {
    // We need to redirect to the /wiki folder.  This will be a virtual directory that is not under the control of the Angular router.
    window.open(`https://angbandos.skarstech.com/wiki`, '_blank');
  }

  public onDeveloperClick() {
    // We need to redirect to the /wiki folder.  This will be a virtual directory that is not under the control of the Angular router.
    window.open(`https://angbandos.skarstech.com/developer`, '_blank');
  }
}
