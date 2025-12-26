import { UntypedFormControl, UntypedFormGroup, Validators } from "@angular/forms";

export class AccountConfirmationFormGroup extends UntypedFormGroup {
  constructor() {
    super({
      emailAddress: new UntypedFormControl({value: "", disabled: true }, Validators.required),
      password: new UntypedFormControl("", Validators.required),
    });
  }

  public get emailAddress(): UntypedFormControl {
    return this.controls.emailAddress as UntypedFormControl;
  }

  public get password(): UntypedFormControl {
    return this.controls.password as UntypedFormControl;
  }
}
