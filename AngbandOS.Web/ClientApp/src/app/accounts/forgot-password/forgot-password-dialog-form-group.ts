import { FormControl, FormGroup, Validators } from "@angular/forms";

export class ForgotPasswordDialogFormGroup extends FormGroup {
  constructor() {
    super({
      emailAddress: new FormControl("", Validators.required)
    });
  }

  public get emailAddress(): FormControl {
    return this.controls.emailAddress as FormControl;
  }
}
