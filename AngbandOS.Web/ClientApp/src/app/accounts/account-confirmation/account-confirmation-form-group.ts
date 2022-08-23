import { FormControl, FormGroup, Validators } from "@angular/forms";

export class AccountConfirmationFormGroup extends FormGroup {
  constructor() {
    super({
      emailAddress: new FormControl({value: "", disabled: true }, Validators.required),
      password: new FormControl("", Validators.required),
    });
  }

  public get emailAddress(): FormControl {
    return this.controls.emailAddress as FormControl;
  }

  public get password(): FormControl {
    return this.controls.password as FormControl;
  }
}
