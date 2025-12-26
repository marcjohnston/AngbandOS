import { UntypedFormControl, UntypedFormGroup, Validators } from "@angular/forms";

export class LoginFormGroup extends UntypedFormGroup {
  constructor() {
    super({
      emailAddress: new UntypedFormControl("", Validators.required),
      password: new UntypedFormControl("", Validators.required),
      rememberMe: new UntypedFormControl(true),
      keepLoggedIn: new UntypedFormControl(true)
    });
  }

  public get emailAddress(): UntypedFormControl {
    return this.controls.emailAddress as UntypedFormControl;
  }

  public get password(): UntypedFormControl {
    return this.controls.password as UntypedFormControl;
  }

  public get rememberMe(): UntypedFormControl {
    return this.controls.rememberMe as UntypedFormControl;
  }

  public get keepLoggedIn(): UntypedFormControl {
    return this.controls.keepLoggedIn as UntypedFormControl;
  }
}
