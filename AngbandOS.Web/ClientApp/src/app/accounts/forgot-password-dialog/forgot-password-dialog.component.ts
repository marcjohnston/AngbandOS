import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, NgZone, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../../modules/error-messages/error-messages.module';
import { ForgotPasswordDialogData } from './forgot-password-dialog-data';
import { ForgotPasswordDialogFormGroup } from './forgot-password-dialog-form-group';
import { FormControl, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-forgot-password-dialog',
  templateUrl: './forgot-password-dialog.component.html',
  styleUrls: ['./forgot-password-dialog.component.scss']
})
export class ForgotPasswordDialogComponent implements OnInit {
  public formGroup = new ForgotPasswordDialogFormGroup();
  public message = "";

  constructor(
    private _dialogRef: MatDialogRef<ForgotPasswordDialogComponent>,
    private _httpClient: HttpClient,
    private _snackBar: MatSnackBar,
    private _zone: NgZone,
    @Inject(MAT_DIALOG_DATA) private _forgotPasswordDialogdata: ForgotPasswordDialogData
  ) {
  }

  ngOnInit(): void {
    this.formGroup.emailAddress.setValue(this._forgotPasswordDialogdata.emailAddress)
  }

  onSendRecoveryLinkClick() {
    this._httpClient.get(`/api/accounts/${this.formGroup.emailAddress.value}/password`).toPromise().then(() => {
      this._dialogRef.close("Password reset email sent.");
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
