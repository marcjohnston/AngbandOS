import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, NgZone } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthenticationService } from '../authentication-service/authentication.service';
import { PostAccount } from './post-account';
import { RegistrationFormGroup } from './registration-form-group';
import { NgClass, NgIf } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatError, MatFormField } from '@angular/material/form-field';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule,
    MatFormField,
    MatError,
    NgClass,
    RouterLink
  ]
})
export class RegistrationComponent {
  public formGroup = new RegistrationFormGroup();
  public messages: string[] = [];

  constructor(
    private _httpClient: HttpClient,
    private _router: Router,
    private _authenticationService: AuthenticationService,
    private _zone: NgZone
  ) {
  }

  public get isAuthenticated(): boolean {
    return this._authenticationService.isAuthenticated;
  }

  public onRegisterClick() {
    if (this.formGroup.valid) {
      this.messages = ["Creating account ..."];
      const postUser: PostAccount = {
        username: this.formGroup.username.value,
        emailAddress: this.formGroup.emailAddress.value,
        password: this.formGroup.password.value
      };

      // Create the user account.
      this._httpClient.post(`/apiv1/accounts`, postUser).toPromise().then(() => {
        // Log the user in automatically.
        this._authenticationService.login(this.formGroup.emailAddress.value, this.formGroup.password.value).then(() => {
          // Remove any previously stored credentials.
          this._authenticationService.removeLocallyStoredCredentials();

          // Navigate to the profile page to send the confirmation email.
          this._zone.run(() => { this._router.navigate([`/accounts/profile`], { queryParams: { confirm: "true" } }) });
        }, (_errorResponse: HttpErrorResponse) => {
          this.messages = [..._errorResponse.error];
        });
      }, (_errorResponse: HttpErrorResponse) => {
        this.messages = [..._errorResponse.error];
      });
    }
  }
}
