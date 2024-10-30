import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../property-metadata-and-configuration';
import { PropertyMetadata } from '../property-metadata';

@Component({
  selector: 'app-game-designer-type',
  templateUrl: './game-designer-type.component.html',
  styleUrls: ['./game-designer-type.component.scss']
})
export class GameDesignerTypeComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  @Input() collections: Map<string, string[]> | undefined = undefined; // Undefined until Angular loads the parameters.

  constructor() { }

  ngOnInit(): void {
  }

  public createArrayChild(activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration, valueIndex: any) {
    const derivedArrayPropertyMetadata = new PropertyMetadata(
      activePropertyMetadataAndConfiguration.propertyMetadata.type,
      valueIndex, // This is how the serialization is naming the tuple fields
      activePropertyMetadataAndConfiguration.propertyMetadata.title,
      activePropertyMetadataAndConfiguration.propertyMetadata.categoryTitle,
      activePropertyMetadataAndConfiguration.propertyMetadata.isNullable,
      activePropertyMetadataAndConfiguration.propertyMetadata.description,
      activePropertyMetadataAndConfiguration.propertyMetadata.defaultValue,
      activePropertyMetadataAndConfiguration.propertyMetadata.propertyMetadatas,
      activePropertyMetadataAndConfiguration.propertyMetadata.keyPropertyName,
      activePropertyMetadataAndConfiguration.propertyMetadata.entityTitle,
      activePropertyMetadataAndConfiguration.propertyMetadata.foreignCollectionName);
    return new PropertyMetadataAndConfiguration(derivedArrayPropertyMetadata, activePropertyMetadataAndConfiguration.configuration[activePropertyMetadataAndConfiguration.propertyMetadata.propertyName]);
  }

  public deleteArrayIndex(index: number) {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName].splice(index, 1);
  }

  public appendArrayItem() {
    //this.activePropertyMetadataAndConfiguration!.propertyMetadata.def
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName].push("");
  }
}
