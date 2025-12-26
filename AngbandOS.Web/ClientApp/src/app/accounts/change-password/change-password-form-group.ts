import { UntypedFormControl, UntypedFormGroup, Validators, ValidatorFn, ValidationErrors, AbstractControl } from "@angular/forms";

export function passwordsMatch(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    return password !== confirmPassword ? { confirmPasswordMismatch: true } : null;
  }
}

export class ChangePasswordFormGroup extends UntypedFormGroup {
  constructor() {
    super({
      currentPassword: new UntypedFormControl("", Validators.required),
      newPassword: new UntypedFormControl("", Validators.required),
      confirmPassword: new UntypedFormControl("", Validators.required),
    }, { validators: passwordsMatch });
  }

  public get currentPassword(): UntypedFormControl {
    return this.controls.currentPassword as UntypedFormControl;
  }

  public get newPassword(): UntypedFormControl {
    return this.controls.newPassword as UntypedFormControl;
  }
}
