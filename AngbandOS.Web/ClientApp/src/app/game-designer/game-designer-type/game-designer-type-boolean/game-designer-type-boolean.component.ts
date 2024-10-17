import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';

@Component({
  selector: 'app-game-designer-type-boolean',
  templateUrl: './game-designer-type-boolean.component.html',
  styleUrls: ['./game-designer-type-boolean.component.scss']
})
export class GameDesignerTypeBooleanComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads it.

  constructor() { }

  ngOnInit(): void {
  }

  public getValue(activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration): string {
    return activePropertyMetadataAndConfiguration.configuration[activePropertyMetadataAndConfiguration.propertyMetadata.propertyName] ?? "";
  }

  public setValue(activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration, event: any) {
    activePropertyMetadataAndConfiguration.configuration[activePropertyMetadataAndConfiguration.propertyMetadata.propertyName] = event.target.value === "" ? null : event.target.value === "true" ? true : false;
  }
}
