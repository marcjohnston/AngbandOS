import { FormControl, FormGroup, Validators } from "@angular/forms";

export class ProfileFormGroup extends FormGroup {
  constructor() {
    super({
      emailAddress: new FormControl("", [ Validators.required, Validators.email ]),
      username: new FormControl("", [Validators.required, Validators.pattern("^[a-zA-Z]{1}[a-zA-Z0-9]{4}$") ])
    });
  }

  public get emailAddress(): FormControl {
    return this.controls.emailAddress as FormControl;
  }

  public get username(): FormControl {
    return this.controls.username as FormControl;
  }
}
