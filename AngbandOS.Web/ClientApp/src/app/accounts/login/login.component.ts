import { Component, NgZone, OnDestroy, OnInit } from '@angular/core';
import { MatLegacyDialog as MatDialog, MatLegacyDialogRef as MatDialogRef } from '@angular/material/legacy-dialog';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../authentication-service/authentication.service';
import { LoginFormGroup } from './login-form-group';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  public formGroup = new LoginFormGroup();
  public message = "";
  private _return: string | null = null;
  private _initSubscriptions = new Subscription();

  constructor(
    private _forgotPasswordDialog: MatDialog,
    private _authenticationService: AuthenticationService,
    private _activatedRoute: ActivatedRoute,
    private _router: Router,
    private _zone: NgZone
  ) {
  }

  ngOnDestroy() {
    this._initSubscriptions.unsubscribe();
  }

  ngOnInit() {
    // Get the query params
    this._activatedRoute.queryParams.subscribe((params: Params) => {
      // Get the return URL, if one was specified.
      this._return = params['return']

      // Setup the formgroup values.
      const emailAddress = localStorage.getItem('email-address');
      const password = localStorage.getItem('password');
      const keepLoggedIn = localStorage.getItem('keep-logged-in');
      this.formGroup.emailAddress.setValue(emailAddress);
      this.formGroup.password.setValue(password);
      this.formGroup.keepLoggedIn.setValue(keepLoggedIn);

      // We need subscriptions to erase the message when the username or password form fields are changed.
      this._initSubscriptions.add(this.formGroup.emailAddress.valueChanges.subscribe(() => this.message = ""));
      this._initSubscriptions.add(this.formGroup.password.valueChanges.subscribe(() => this.message = ""));
    });
  }

  public get isAuthenticated(): boolean {
    return this._authenticationService.isAuthenticated;
  }

  public onLoginClick() {
    this._authenticationService.login(this.formGroup.emailAddress.value, this.formGroup.password.value).then(() => {
      if (this._return !== null) {
        if (this.formGroup.rememberMe.value) {
          this._authenticationService.storeCredentialsLocally(this.formGroup.emailAddress.value, this.formGroup.password.value, this.formGroup.keepLoggedIn.value);
        } else {
          this._authenticationService.removeLocallyStoredCredentials();
        }

        // This is running outside of the Angular zone.
        this._zone.run(() => this._router.navigate([this._return]));
      } else {
        this._zone.run(() => { this.message = "" });
      }
    }, () => {
        // Erase the password.  We need to do this before the setting the message because we have a subscription that will erase the message.
        this.formGroup.password.setValue("");

        // Now set the message.
        this.message = "Login failed.";
    });
  }
}
