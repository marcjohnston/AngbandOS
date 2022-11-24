import { FormControl, FormGroup } from "@angular/forms";

export class PreferencesDialogFormGroup extends FormGroup {
  constructor() {
    super({
      fontName: new FormControl(""),
      fontSize: new FormControl(""),
      f1Macro: new FormControl(""),
      f2Macro: new FormControl(""),
      f3Macro: new FormControl(""),
      f4Macro: new FormControl(""),
      f5Macro: new FormControl(""),
      f6Macro: new FormControl(""),
      f7Macro: new FormControl(""),
      f8Macro: new FormControl(""),
      f9Macro: new FormControl(""),
      f10Macro: new FormControl(""),
      f11Macro: new FormControl(""),
      f12Macro: new FormControl("")
    });
  }

  public get fontName(): FormControl {
    return this.controls.fontName as FormControl;
  }
  public get fontSize(): FormControl {
    return this.controls.fontSize as FormControl;
  }
  public get f1Macro(): FormControl {
    return this.controls.f1Macro as FormControl;
  }
  public get f2Macro(): FormControl {
    return this.controls.f2Macro as FormControl;
  }
  public get f3Macro(): FormControl {
    return this.controls.f3Macro as FormControl;
  }
  public get f4Macro(): FormControl {
    return this.controls.f4Macro as FormControl;
  }
  public get f5Macro(): FormControl {
    return this.controls.f5Macro as FormControl;
  }
  public get f6Macro(): FormControl {
    return this.controls.f6Macro as FormControl;
  }
  public get f7Macro(): FormControl {
    return this.controls.f7Macro as FormControl;
  }
  public get f8Macro(): FormControl {
    return this.controls.f8Macro as FormControl;
  }
  public get f9Macro(): FormControl {
    return this.controls.f9Macro as FormControl;
  }
  public get f10Macro(): FormControl {
    return this.controls.f10Macro as FormControl;
  }
  public get f11Macro(): FormControl {
    return this.controls.f11Macro as FormControl;
  }
  public get f12Macro(): FormControl {
    return this.controls.f12Macro as FormControl;
  }
}
