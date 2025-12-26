import { UntypedFormControl, UntypedFormGroup } from "@angular/forms";

export class PreferencesDialogFormGroup extends UntypedFormGroup {
  constructor() {
    super({
      fontName: new UntypedFormControl(""),
      fontSize: new UntypedFormControl(""),
      f1Macro: new UntypedFormControl(""),
      f2Macro: new UntypedFormControl(""),
      f3Macro: new UntypedFormControl(""),
      f4Macro: new UntypedFormControl(""),
      f5Macro: new UntypedFormControl(""),
      f6Macro: new UntypedFormControl(""),
      f7Macro: new UntypedFormControl(""),
      f8Macro: new UntypedFormControl(""),
      f9Macro: new UntypedFormControl(""),
      f10Macro: new UntypedFormControl(""),
      f11Macro: new UntypedFormControl(""),
      f12Macro: new UntypedFormControl("")
    });
  }

  public get fontName(): UntypedFormControl {
    return this.controls.fontName as UntypedFormControl;
  }
  public get fontSize(): UntypedFormControl {
    return this.controls.fontSize as UntypedFormControl;
  }
  public get f1Macro(): UntypedFormControl {
    return this.controls.f1Macro as UntypedFormControl;
  }
  public get f2Macro(): UntypedFormControl {
    return this.controls.f2Macro as UntypedFormControl;
  }
  public get f3Macro(): UntypedFormControl {
    return this.controls.f3Macro as UntypedFormControl;
  }
  public get f4Macro(): UntypedFormControl {
    return this.controls.f4Macro as UntypedFormControl;
  }
  public get f5Macro(): UntypedFormControl {
    return this.controls.f5Macro as UntypedFormControl;
  }
  public get f6Macro(): UntypedFormControl {
    return this.controls.f6Macro as UntypedFormControl;
  }
  public get f7Macro(): UntypedFormControl {
    return this.controls.f7Macro as UntypedFormControl;
  }
  public get f8Macro(): UntypedFormControl {
    return this.controls.f8Macro as UntypedFormControl;
  }
  public get f9Macro(): UntypedFormControl {
    return this.controls.f9Macro as UntypedFormControl;
  }
  public get f10Macro(): UntypedFormControl {
    return this.controls.f10Macro as UntypedFormControl;
  }
  public get f11Macro(): UntypedFormControl {
    return this.controls.f11Macro as UntypedFormControl;
  }
  public get f12Macro(): UntypedFormControl {
    return this.controls.f12Macro as UntypedFormControl;
  }
}
