import { FormControl, FormGroup, Validators, ValidatorFn, ValidationErrors, AbstractControl } from "@angular/forms";

export function passwordsMatch(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    return password !== confirmPassword ? { confirmPasswordMismatch: true } : null;
  }
}

export class ResetPasswordFormGroup extends FormGroup {
  constructor() {
    super({
      newPassword: new FormControl("", Validators.required),
      confirmPassword: new FormControl("", Validators.required),
    }, { validators: passwordsMatch });
  }

  public get newPassword(): FormControl {
    return this.controls.newPassword as FormControl;
  }
}
