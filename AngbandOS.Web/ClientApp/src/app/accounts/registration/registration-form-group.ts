import { AbstractControl, UntypedFormControl, UntypedFormGroup, Validators, ValidatorFn, ValidationErrors } from "@angular/forms";

export function passwordsMatch(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    if (!password || !confirmPassword) {
      return null;
    }

    return password !== confirmPassword ? { passwordMismatch: true } : null;
  }
}

export class RegistrationFormGroup extends UntypedFormGroup {
  constructor() {
    super({
      username: new UntypedFormControl("", [Validators.required, Validators.pattern("^[a-zA-Z]{1}[a-zA-Z0-9]*$"), Validators.minLength(5), Validators.maxLength(15)]),
      emailAddress: new UntypedFormControl("", [ Validators.required, Validators.email ]),
      password: new UntypedFormControl("", [Validators.required, Validators.minLength(8)]),
      confirmPassword: new UntypedFormControl("", Validators.required),
    }, { validators: passwordsMatch() });
  }

  public get username(): UntypedFormControl {
    return this.controls.username as UntypedFormControl;
  }

  public get emailAddress(): UntypedFormControl {
    return this.controls.emailAddress as UntypedFormControl;
  }

  public get password(): UntypedFormControl {
    return this.controls.password as UntypedFormControl;
  }

  public get confirmPassword(): UntypedFormControl {
    return this.controls.confirmPassword as UntypedFormControl;
  }
}
