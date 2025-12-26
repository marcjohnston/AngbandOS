import { UntypedFormControl, UntypedFormGroup, Validators } from "@angular/forms";

export class ForgotPasswordDialogFormGroup extends UntypedFormGroup {
  constructor() {
    super({
      emailAddress: new UntypedFormControl("", Validators.required)
    });
  }

  public get emailAddress(): UntypedFormControl {
    return this.controls.emailAddress as UntypedFormControl;
  }
}
