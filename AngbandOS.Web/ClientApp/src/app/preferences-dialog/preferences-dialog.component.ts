import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PreferencesDialogData } from './preferences-dialog-data';
import { PreferencesDialogFormGroup } from './preferences-dialog-form-group';

@Component({
  selector: 'app-preferences-dialog',
  templateUrl: './preferences-dialog.component.html',
  styleUrls: ['./preferences-dialog.component.scss']
})
export class PreferencesDialogComponent implements OnInit {
  public formGroup = new PreferencesDialogFormGroup();

  constructor(
    @Inject(MAT_DIALOG_DATA) private _dialogData: PreferencesDialogData,
    private _dialogRef: MatDialogRef<PreferencesDialogComponent>
  ) {
  }

  ngOnInit(): void {
    if (this._dialogData !== null) {
      this.formGroup.fontName.setValue(this._dialogData.fontName);
      this.formGroup.fontSize.setValue(this._dialogData.fontSize);
      this.formGroup.f1Macro.setValue(this._dialogData.f1Macro);
      this.formGroup.f2Macro.setValue(this._dialogData.f2Macro);
      this.formGroup.f3Macro.setValue(this._dialogData.f3Macro);
      this.formGroup.f4Macro.setValue(this._dialogData.f4Macro);
      this.formGroup.f5Macro.setValue(this._dialogData.f5Macro);
      this.formGroup.f6Macro.setValue(this._dialogData.f6Macro);
      this.formGroup.f7Macro.setValue(this._dialogData.f7Macro);
      this.formGroup.f8Macro.setValue(this._dialogData.f8Macro);
      this.formGroup.f9Macro.setValue(this._dialogData.f9Macro);
      this.formGroup.f10Macro.setValue(this._dialogData.f10Macro);
      this.formGroup.f11Macro.setValue(this._dialogData.f11Macro);
      this.formGroup.f12Macro.setValue(this._dialogData.f12Macro);
    }
  }

  onSubmit() {
    if (this.formGroup.valid) {
      this._dialogData.fontName = this.formGroup.fontName.value;
      this._dialogData.fontSize = this.formGroup.fontSize.value;
      this._dialogData.f1Macro = this.formGroup.f1Macro.value;
      this._dialogData.f2Macro = this.formGroup.f2Macro.value;
      this._dialogData.f3Macro = this.formGroup.f3Macro.value;
      this._dialogData.f4Macro = this.formGroup.f4Macro.value;
      this._dialogData.f5Macro = this.formGroup.f5Macro.value;
      this._dialogData.f6Macro = this.formGroup.f6Macro.value;
      this._dialogData.f7Macro = this.formGroup.f7Macro.value;
      this._dialogData.f8Macro = this.formGroup.f8Macro.value;
      this._dialogData.f9Macro = this.formGroup.f9Macro.value;
      this._dialogData.f10Macro = this.formGroup.f10Macro.value;
      this._dialogData.f11Macro = this.formGroup.f11Macro.value;
      this._dialogData.f12Macro = this.formGroup.f12Macro.value;
      this._dialogRef.close(this._dialogData);
    }
  }
}
