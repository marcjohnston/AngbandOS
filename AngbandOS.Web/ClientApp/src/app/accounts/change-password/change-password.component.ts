import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, NgZone } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../../modules/error-messages/error-messages.module';
import { AuthenticationService } from '../authentication-service/authentication.service';
import { ChangePasswordFormGroup } from './change-password-form-group';
import { ChangePasswordRequest } from './change-password-request';
import { NgIf } from '@angular/common';
import { MatFormField } from '@angular/material/form-field';
import { RouterLink } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    MatFormField,
    RouterLink,
    ReactiveFormsModule
  ]
})
export class ChangePasswordComponent {
  public formGroup = new ChangePasswordFormGroup();
  public messages: string[] = [];

  constructor(
    private _httpClient: HttpClient,
    private _authenticationService: AuthenticationService,
    private _snackBar: MatSnackBar,
    private _zone: NgZone
  ) { }

  public onChangePasswordClick() {
    if (this.formGroup.valid && this._authenticationService.currentUser.value !== null) {
      const changePasswordRequest: ChangePasswordRequest = {
        currentPassword: this.formGroup.currentPassword.value,
        newPassword: this.formGroup.newPassword.value
      };

      this._httpClient.put(`/apiv1/accounts/password`, changePasswordRequest).toPromise().then(() => {
        this._zone.run(() => { this.messages = ["Password updated."] });
        this.formGroup.reset();
      }, (_errorResponse: HttpErrorResponse) => {
        this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
          duration: 5000
        });
        this._zone.run(() => { this.messages = ["Update failed."] });
      });
    }
  }
}
