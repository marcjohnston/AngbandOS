import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, NgZone } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../../modules/error-messages/error-messages.module';
import { ForgotPasswordDialogFormGroup } from './forgot-password-dialog-form-group';
import { MatError, MatFormField } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss'],
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormField,
    MatError
  ]
})
export class ForgotPasswordComponent {
  public formGroup = new ForgotPasswordDialogFormGroup();
  public message = "";

  constructor(
    private _httpClient: HttpClient,
    private _snackBar: MatSnackBar,
    private _zone: NgZone,
  ) {
  }

  onSendRecoveryLinkClick() {
    this._httpClient.get(`/apiv1/accounts/${this.formGroup.emailAddress.value}/password`).toPromise().then(() => {
      this.message = "Password reset email sent.";
    }, (_errorResponse: HttpErrorResponse) => {
      this._zone.run(() => {
        // Display the message with no label title.
        this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
          duration: 5000
        });
      });
      this.message = "Unable to send password reset email.";
    });
  }
}
