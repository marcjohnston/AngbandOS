import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../authentication-service/authentication.service';
import { ProfileFormGroup } from './profile-form-group';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../../modules/error-messages/error-messages.module';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit, OnDestroy {
  public formGroup = new ProfileFormGroup();
  public messages: string[] | null = null;
  private _initSubscriptions = new Subscription();

  constructor(
    private _httpClient: HttpClient,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
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
        this.messages = [`Confirmation email sent.`, `Please click on the link in your email to confirm your email address.`];
      }, (_errorResponse: HttpErrorResponse) => {
        this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
          duration: 5000
        });
        this.messages = [_errorResponse.error];
      });
    }
  }

  public onResendConfirmationEmailClick() {
    this.sendConfirmationEmail();
  }

  public onSaveClick() {
    this.formGroup.disable();
  }

  public onCancelClick() {
    this.formGroup.disable();
  }
}
