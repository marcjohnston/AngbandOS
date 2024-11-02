import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../property-metadata-and-configuration';
import { PropertyMetadata } from '../property-metadata';

@Component({
  selector: 'app-game-designer-property',
  templateUrl: './game-designer-property.component.html',
  styleUrls: ['./game-designer-property.component.scss']
})
export class GameDesignerPropertyComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  @Input() collections: Map<string, string[]> | undefined = undefined; // Undefined until Angular loads the parameters.

  constructor() { }

  ngOnInit(): void {
  }

  public addEntity() {
    const newCollectionEntity: any[] = [];
    for (let index = 0; index < this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyMetadatas!.length; index++) {
      const tuplePropertyMetadata: PropertyMetadata = this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyMetadatas![index];
      newCollectionEntity.push(tuplePropertyMetadata.defaultValue);
    }
    this.activePropertyMetadataAndConfiguration?.configuration.push(newCollectionEntity);
  }

  public deleteEntity(index: number) {
    this.activePropertyMetadataAndConfiguration?.configuration.splice(index, 1);
  }

  /**
   * Creates a new PropertyMetadataAndConfiguration object from a child property metadata.  This is used by the game-designer-type component for recursion.
   * @param propertyMetadata
   * @returns
   */
  public createChild(activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration, childPropertyMetadata: PropertyMetadata): PropertyMetadataAndConfiguration {
    return new PropertyMetadataAndConfiguration(childPropertyMetadata, activePropertyMetadataAndConfiguration.configuration);
  }
}
