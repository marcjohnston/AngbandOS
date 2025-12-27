import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, NgZone, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../authentication-service/authentication.service';
import { ProfileFormGroup } from './profile-form-group';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../../modules/error-messages/error-messages.module';
import { UpdateAccountRequest } from '../change-password/update-account-request';
import { NgIf } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormField } from '@angular/material/form-field';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    RouterLink,
    ReactiveFormsModule,
    MatFormField
  ]
})
export class ProfileComponent implements OnInit, OnDestroy {
  public formGroup = new ProfileFormGroup();
  public messages: string[] | null = null;
  private _initSubscriptions = new Subscription();

  constructor(
    private _httpClient: HttpClient,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private _zone: NgZone,
    private _authenticationService: AuthenticationService
  ) { }

  ngOnInit(): void {
    this.formGroup.emailAddress.setValue(this._authenticationService.currentUser.value?.email);
    this.formGroup.username.setValue(this._authenticationService.currentUser.value?.username);
    this.formGroup.disable();

    this._initSubscriptions.add(this._activatedRoute.queryParamMap.subscribe((paramMap) => {
      // Validate the query parameters.
      // We will be expecting an email address parameter if this is an email validation.
      console.log(paramMap.get("confirm"));
      if (paramMap.get("confirm") === "true") {
        this.sendConfirmationEmail();
      }
    }));
  }

  ngOnDestroy() {
    this._initSubscriptions.unsubscribe();
  }

  public onEditClick() {
    this.formGroup.enable();
  }

  public get emailVerified(): boolean {
    if (this._authenticationService.currentUser.value == null || this._authenticationService.currentUser.value.emailVerified == undefined) {
      return false;
    } else {
      return this._authenticationService.currentUser.value.emailVerified;
    }
  }

  private sendConfirmationEmail() {
    if (this._authenticationService.currentUser.value !== null && this._authenticationService.currentUser.value.email !== undefined) {
      this.messages = ["Sending confirmation email ..."];
      const emailAddress: string = this._authenticationService.currentUser.value.email;
      this._httpClient.get(`/apiv1/accounts/verification`).toPromise().then(() => {
        this._zone.run(() => {
          this.messages = [`Confirmation email sent.`, `Please click on the link in your email to confirm your email address.`];
        });
      }, (_errorResponse: HttpErrorResponse) => {
        this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
          duration: 5000
        });
        this._zone.run(() => {
          this.messages = [_errorResponse.error];
        });
      });
    }
  }

  public onResendConfirmationEmailClick() {
    this.sendConfirmationEmail();
  }

  public onSaveClick() {
    this.formGroup.disable();

    if (this.formGroup.valid && this._authenticationService.currentUser.value !== null) {
      const changePasswordRequest: UpdateAccountRequest = {
        username: this.formGroup.username.value,
        emailAddress: this.formGroup.emailAddress.value
      };

      this._httpClient.put(`/apiv1/account`, changePasswordRequest).toPromise().then(() => {
        this._zone.run(() => {
          this.messages = ["Updated.  If you updated your email address, you must confirm the update from your inbox."]
        });
        this.formGroup.reset();
      }, (_errorResponse: HttpErrorResponse) => {
        this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
          duration: 5000
        });
        this._zone.run(() => {
          this.messages = ["Update failed."]
        });
      });
    }
  }

  public onCancelClick() {
    this.formGroup.disable();
  }
}
