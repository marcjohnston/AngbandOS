import { UntypedFormControl, UntypedFormGroup, Validators } from "@angular/forms";

export class ProfileFormGroup extends UntypedFormGroup {
  constructor() {
    super({
      emailAddress: new UntypedFormControl("", [ Validators.required, Validators.email ]),
      username: new UntypedFormControl("", [Validators.required, Validators.pattern("^[a-zA-Z]{1}[a-zA-Z0-9]{4}$") ])
    });
  }

  public get emailAddress(): UntypedFormControl {
    return this.controls.emailAddress as UntypedFormControl;
  }

  public get username(): UntypedFormControl {
    return this.controls.username as UntypedFormControl;
  }
}
