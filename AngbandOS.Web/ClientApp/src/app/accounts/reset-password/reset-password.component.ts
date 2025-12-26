import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, NgZone, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ResetPasswordFormGroup } from './reset-password-form-group';
import { ResetPasswordRequest } from './reset-password-request';
import { MatLegacySnackBar as MatSnackBar } from '@angular/material/legacy-snack-bar';
import { ErrorMessages } from '../../modules/error-messages/error-messages.module';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  private _resetToken: string | null = null;
  public formGroup = new ResetPasswordFormGroup();
  private _initSubscriptions = new Subscription();
  private _emailAddress: string | null = null;
  public messages: string[] = [];
  public errors: string[] = [];

  constructor(
    private _httpClient: HttpClient,
    private _snackBar: MatSnackBar,
    private _activatedRoute: ActivatedRoute,
    private _zone: NgZone
  ) {
  }

  ngOnInit(): void {
    this._initSubscriptions.add(this._activatedRoute.queryParamMap.subscribe((paramMap) => {
      // Validate the query parameters.  There are two modes for this component: password-recovery and change-password.
      // Check to see if this is password-recovery mode.  The email address and reset-password token will be specified on the query.
      this._emailAddress = paramMap.get("emailAddress");
      this._resetToken = paramMap.get("token");

      if (this._emailAddress === null || this._emailAddress.length === 0) {
        this.errors = this.errors.concat("Invalid email address.  Check the URL of the link.");
      }
      if (this._resetToken === null || this._resetToken.length === 0) {
        this.errors = this.errors.concat("Invalid password reset token.  Check the URL of the link.");
      }
    }));
  }

  public onUpdatePasswordClick() {
    if (this.formGroup.valid && this._resetToken !== null) {
      const resetPasswordRequest: ResetPasswordRequest = {
        resetPasswordToken: this._resetToken,
        newPassword: this.formGroup.newPassword.value
      };

      this._httpClient.post(`/apiv1/accounts/${this._emailAddress}/password`, resetPasswordRequest).toPromise().then(() => {
        this._zone.run(() => { this.messages = ["Password updated."] });
        this.formGroup.reset();
      }, (_errorResponse: HttpErrorResponse) => {
        this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
          duration: 5000
        });
        this._zone.run(() => { this.messages = ["Reset failed."] });
      });
    }
  }
}
