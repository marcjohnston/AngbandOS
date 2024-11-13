import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { SelectOption } from '../../select-option';
import { ColorEnum } from '../../../modules/color-enum/color-enum.module';
import { convertToTitleCase } from '../../../modules/strings-library/strings-library.module';

@Component({
  selector: 'app-game-designer-type-color',
  templateUrl: './game-designer-type-color.component.html',
  styleUrls: ['./game-designer-type-color.component.scss']
})
export class GameDesignerTypeColorComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  @ViewChild('select') select!: ElementRef;
  public errorMessage: string = "";
  public unmodifiedValue: ColorEnum | undefined = undefined; // The possible values will be true, false or "" to represent null.
  public colorOptions: SelectOption[] | undefined = undefined;

  constructor() { }

  ngOnInit(): void {
    this.unmodifiedValue = this.getValue();

    this.colorOptions = [];
    for (const colorName in ColorEnum) {
      if (typeof ColorEnum[colorName] === "number") {
        this.colorOptions.push({ text: convertToTitleCase(colorName), value: ColorEnum[colorName] });
      }
    }

    // Sort the color options by text.
    this.colorOptions.sort((a, b) => a.text.localeCompare(b.text));
 }

  /**
   * Returns the current value of the configuration.
   * @returns "true", "false" or "" for null
   */
  public getValue(): ColorEnum {
    return this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] ?? "";
  }

  public setValue() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.select.nativeElement.value === "" ? null : this.select.nativeElement.value;
  }

  public undo() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.unmodifiedValue;
  }
}
