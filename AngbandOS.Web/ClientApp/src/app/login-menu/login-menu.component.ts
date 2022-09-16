import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { Subscription } from 'rxjs';
import { UserDetails } from '../accounts/authentication-service/user-details';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.scss']
})
export class LoginMenuComponent implements OnInit, OnDestroy {
  public username: string | null = null;
  private _initSubscriptions = new Subscription();
  public isAuthenticated: boolean = false;
  public isAdministrator: boolean = false;

  constructor(
    private _authenticationService: AuthenticationService,
  ) { }

  ngOnInit() {
    this._initSubscriptions.add(this._authenticationService.currentUser.subscribe((_userDetails: UserDetails | null) => {
      if (_userDetails == null || _userDetails.username == null) {
        this.username = null;
        this.isAuthenticated = false;
      } else {
        this.username = _userDetails.username;
        this.isAuthenticated = true;
        this.isAdministrator = (_userDetails.isAdmin === true);
      }
    }));
  }

  ngOnDestroy() {
    this._initSubscriptions.unsubscribe();
  }
}
