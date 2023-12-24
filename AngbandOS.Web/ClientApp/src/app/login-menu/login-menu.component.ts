import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { Subscription } from 'rxjs';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { ActivatedRoute, Router } from '@angular/router';

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
    private _router: Router,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this._initSubscriptions.add(this._authenticationService.currentUser.subscribe((_userDetails: UserDetails | null) => {
      if (_userDetails == null || _userDetails.username == null) {
        // User is not logged in.
        this.username = null;
        this.isAuthenticated = false;
        this.isAdministrator = false;
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

  public onWikiClick() {
    // We need to redirect to the /wiki folder.  This will be a virtual directory that is not under the control of the Angular router.
    window.open(`https://angbandos.skarstech.com/wiki`, '_blank');
  }

  public onDeveloperClick() {
    // We need to redirect to the /wiki folder.  This will be a virtual directory that is not under the control of the Angular router.
    window.open(`https://angbandos.skarstech.com/developer`, '_blank');
  }
}
