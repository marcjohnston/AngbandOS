import { AbstractControl, UntypedFormControl, UntypedFormGroup, Validators, ValidatorFn, ValidationErrors } from "@angular/forms";

export function passwordsMatch(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    return password !== confirmPassword ? { confirmPasswordMismatch: true } : null;
  }
}

export class RegistrationFormGroup extends UntypedFormGroup {
  constructor() {
    super({
      username: new UntypedFormControl("", [Validators.required, Validators.pattern("^[a-zA-Z]{1}[a-zA-Z0-9]*$"), Validators.minLength(5), Validators.maxLength(15)]),
      emailAddress: new UntypedFormControl("", [ Validators.required, Validators.email ]),
      password: new UntypedFormControl("", Validators.required),
      confirmPassword: new UntypedFormControl("", Validators.required),
    }, { validators: passwordsMatch });
  }

  public get username(): UntypedFormControl {
    return this.controls.username as UntypedFormControl;
  }

  public get usernameError(): string {
    if (this.username.hasError('required')) {
      return "This field is required.";
    }

    if (this.username.hasError('minlength')) {
      return "Must be at least 5 characters in length.";
    }

    if (this.username.hasError('maxlength')) {
      return "Cannot be longer than 15 characters in length.";
    }

    if (this.username.hasError('pattern')) {
      return "Alphanumeric only and must start with a letter.";
    }

    return '';
  }

  public get emailAddress(): UntypedFormControl {
    return this.controls.emailAddress as UntypedFormControl;
  }

  public get emailError(): string {
    if (this.emailAddress.hasError('required')) {
      return "This field is required.";
    }

    return this.emailAddress.hasError('email') ? 'Invalid email address.' : '';
  }

  public get password(): UntypedFormControl {
    return this.controls.password as UntypedFormControl;
  }

  public get passwordError(): string {
    return this.password.hasError('required') ? "This field is required." : "";
  }

  public get confirmPassword(): UntypedFormControl {
    return this.controls.confirmPassword as UntypedFormControl;
  }

  public get confirmError(): string {
    return this.hasError('confirmPasswordMismatch') ? 'Passwords do not match.' : '';
  }

}
