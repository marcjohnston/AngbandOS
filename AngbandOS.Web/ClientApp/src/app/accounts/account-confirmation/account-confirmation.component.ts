import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, NgZone, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../authentication-service/authentication.service';
import { AccountConfirmationFormGroup } from './account-confirmation-form-group';
import { PutUser } from './put-user';
import { UserDetails } from '../authentication-service/user-details';
import { MatLegacySnackBar as MatSnackBar } from '@angular/material/legacy-snack-bar';
import { ErrorMessages } from '../../modules/error-messages/error-messages.module';

@Component({
  selector: 'app-account-confirmation',
  templateUrl: './account-confirmation.component.html',
  styleUrls: ['./account-confirmation.component.scss']
})
export class AccountConfirmationComponent implements OnInit, OnDestroy {
  private _initSubscriptions = new Subscription();
  public errors: string[] = [];
  public messages: string[] = [];
  public formGroup = new AccountConfirmationFormGroup();
  public emailAddress: string | null = null; // This is the email address supplied in the query.
  public verificationToken: string | null = null; // This is the verification token supplied in the query.
  public isAuthenticated = false;

  constructor(
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService,
    private _httpClient: HttpClient,
    private _zone: NgZone
  ) {
  }

  ngOnInit(): void {
    this._initSubscriptions.add(this._activatedRoute.queryParamMap.subscribe((paramMap) => {
      // Validate the query parameters.
      // We will be expecting an email address parameter if this is an email validation.
      this.emailAddress = paramMap.get("emailAddress");
      this.verificationToken = paramMap.get("token");
      this.formGroup.emailAddress.setValue(this.emailAddress); // This is ONLY a visual cue for the user.

      this.errors = [];
      if (this.emailAddress === null || this.emailAddress.length === 0) {
        this.errors = this.errors.concat("Invalid email address.");
      }
      if (this.verificationToken === null || this.verificationToken.length === 0) {
        this.errors = this.errors.concat("Invalid verification token.");
      }

      // Attempt a verification.
      this.verify();
    }));

    // Subscribe to changes in the login.  This may be performed by the user or an automatic login.
    this._initSubscriptions.add(this._authenticationService.currentUser.subscribe((u: UserDetails | null) => {
      if (u !== null) {
        this.isAuthenticated = true;
        // Being that current user is a behavior subject, the first call not still not be authenticated.
        this.verify();
      }
    }));
  }

  ngOnDestroy() {
    this._initSubscriptions.unsubscribe();
  }

  private verify() {
    if (this.errors.length === 0 && this.isAuthenticated && this.verificationToken !== null) {
      const putUser: PutUser = {
        token: this.verificationToken
      };
      this._httpClient.put<string[] | null>(`/apiv1/accounts/verification`, putUser).toPromise().then(() => {
        if (this._authenticationService.currentUser.value !== null) {
          this._authenticationService.currentUser.value.emailVerified = true;
        }
        this._zone.run(() => { this.messages = ["Account confirmed.", "Click on the logo to return to the home screen."] });
      }, (_errorResponse: HttpErrorResponse) => {
        this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
          duration: 5000
        });
      });
    }
  }

  public onLoginClick() {
    if (this.emailAddress !== null) {
      this.messages = ["Confirming your account."];
      // The user needed to login.  Log the user in an then check the verification.
      this._authenticationService.login(this.emailAddress, this.formGroup.password.value).then(() => {
        //this.verify(); // This is done automatically once the login is confirmed.
      }, () => {
        this.messages = ["Login failed."];
      });
    }
  }

  public onForgotPasswordClick() {

  }
}
