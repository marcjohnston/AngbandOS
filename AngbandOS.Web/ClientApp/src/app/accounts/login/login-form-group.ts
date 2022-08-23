import { FormControl, FormGroup, Validators } from "@angular/forms";

export class LoginFormGroup extends FormGroup {
  constructor() {
    super({
      emailAddress: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required),
      rememberMe: new FormControl(true),
      keepLoggedIn: new FormControl(true)
    });
  }

  public get emailAddress(): FormControl {
    return this.controls.emailAddress as FormControl;
  }

  public get password(): FormControl {
    return this.controls.password as FormControl;
  }

  public get rememberMe(): FormControl {
    return this.controls.rememberMe as FormControl;
  }

  public get keepLoggedIn(): FormControl {
    return this.controls.keepLoggedIn as FormControl;
  }
}
