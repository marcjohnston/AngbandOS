import { AbstractControl, FormControl, FormGroup, Validators, ValidatorFn, ValidationErrors } from "@angular/forms";

export function passwordsMatch(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    return password !== confirmPassword ? { confirmPasswordMismatch: true } : null;
  }
}

export class RegistrationFormGroup extends FormGroup {
  constructor() {
    super({
      username: new FormControl("", [Validators.required, Validators.pattern("^[a-zA-Z]{1}[a-zA-Z0-9]*$"), Validators.minLength(5), Validators.maxLength(15)]),
      emailAddress: new FormControl("", [ Validators.required, Validators.email ]),
      password: new FormControl("", Validators.required),
      confirmPassword: new FormControl("", Validators.required),
    }, { validators: passwordsMatch });
  }

  public get username(): FormControl {
    return this.controls.username as FormControl;
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

  public get emailAddress(): FormControl {
    return this.controls.emailAddress as FormControl;
  }

  public get emailError(): string {
    if (this.emailAddress.hasError('required')) {
      return "This field is required.";
    }

    return this.emailAddress.hasError('email') ? 'Invalid email address.' : '';
  }

  public get password(): FormControl {
    return this.controls.password as FormControl;
  }

  public get passwordError(): string {
    return this.password.hasError('required') ? "This field is required." : "";
  }

  public get confirmPassword(): FormControl {
    return this.controls.confirmPassword as FormControl;
  }

  public get confirmError(): string {
    return this.hasError('confirmPasswordMismatch') ? 'Passwords do not match.' : '';
  }

}
