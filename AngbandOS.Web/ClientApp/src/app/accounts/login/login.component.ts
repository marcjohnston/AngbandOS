import { Component, NgZone, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Params, Router, RouterLink } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../authentication-service/authentication.service';
import { LoginFormGroup } from './login-form-group';
import { NgIf } from '@angular/common';
import { MatFormField } from '@angular/material/form-field';
import { MatCheckbox } from '@angular/material/checkbox';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';
import { NavMenuComponent } from '../../nav-menu/nav-menu.component';
import { ChatComponent } from '../../chat/chat.component';
import { FooterComponent } from '../../footer/footer.component';
import { MasterLayoutComponent } from '../../master-layout/master-layout.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [
    RouterLink,
    NgIf,
    ChatComponent,
    MatFormField,
    MatCheckbox,
    MatInputModule,
    ReactiveFormsModule,
    FooterComponent,
    NavMenuComponent,
    MasterLayoutComponent,
    MatButtonModule
  ]
})
export class LoginComponent implements OnInit, OnDestroy {
  public formGroup = new LoginFormGroup();
  public message = "";
  private _return: string | null = null;
  private _initSubscriptions = new Subscription();

  constructor(
    private _forgotPasswordDialog: MatDialog,
    private _snackBar: MatSnackBar,
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
      this._return = params['return'];

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
      // Check for the remember me checkbox functionality.  This only works for successful logins.
      if (this.formGroup.rememberMe.value) {
        this._authenticationService.storeCredentialsLocally(this.formGroup.emailAddress.value, this.formGroup.password.value, this.formGroup.keepLoggedIn.value);
      } else {
        this._authenticationService.removeLocallyStoredCredentials();
      }

      if (this._return !== undefined && this._return !== null) {
        // This is running outside of the Angular zone.
        this._zone.run(() => this._router.navigate([this._return]));
      } else {
        this._router.navigate(['/']);
      }
    }, (reason: any) => {
      // Erase the password.  We need to do this before the setting the message because we have a subscription that will erase the message.
      this.formGroup.password.setValue("");

      // Now set the message.
      var errorMessage: string | undefined = "Error";
      if (reason instanceof HttpErrorResponse) {
        const httpErrorResponse: HttpErrorResponse = reason;
        switch (httpErrorResponse.status) {
          case 200:
            errorMessage = undefined;
            break;
          case 404:
            errorMessage = "Login failed.";
            break;
          case 503:
            errorMessage = "Service unavailable";
            break;
        }
      }
      if (errorMessage != undefined)
        this._snackBar.open(errorMessage, "", { duration: 5000 });
    });
  }
}
