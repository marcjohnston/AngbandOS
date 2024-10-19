import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';

@Component({
  selector: 'app-game-designer-type-integer',
  templateUrl: './game-designer-type-integer.component.html',
  styleUrls: ['./game-designer-type-integer.component.scss']
})
export class GameDesignerTypeIntegerComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads it.
  @ViewChild('input') input!: ElementRef;
  public unmodifiedValue: string | null | undefined = undefined;
  public errorMessage: string = "";

  constructor() { }

  ngOnInit(): void {
    this.unmodifiedValue = this.getValue();
  }

  public undo() {
    this.input.nativeElement.value = this.unmodifiedValue;
    this.setValue();
  }

  public getValue(): string | null {
    return this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] ?? "";
  }

  public validate(): number | null {
    const INT32_MAX: number = 2147483647;  // 2^31 - 1
    const INT32_MIN: number = -2147483648; // -2^31
    if (this.input.nativeElement.value == "") {
      if (!this.activePropertyMetadataAndConfiguration?.propertyMetadata.isNullable) {
        this.errorMessage = "Value is required.";
        return NaN;
      } else {
        return null;
      }
    } else {
      const intPattern = /^[-+]?\d+$/; // Only allow digits (no decimal points or exponents)
      if (!intPattern.test(this.input.nativeElement.value)) {
        this.errorMessage = "Invalid value.  Must be a positive or negative integer.";
        return NaN;
      } else {
        const intValue = Number(this.input.nativeElement.value);
        if (isNaN(intValue)) {
          this.errorMessage = "Invalid value.  Must be a positive or negative integer.";
          return NaN;
        } else if (intValue < INT32_MIN || intValue > INT32_MAX) {
          this.errorMessage = "Value out of range.";
          return NaN;
        } else {
          this.errorMessage = "";
          return intValue;
        }
      }
    }
  }

  public setValue() {
    const intValue = this.validate();
    if (intValue === null || !isNaN(intValue)) {
      this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = intValue;
      this.input.nativeElement.value = intValue;
    }
  }
}
