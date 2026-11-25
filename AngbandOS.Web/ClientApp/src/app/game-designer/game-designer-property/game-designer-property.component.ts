import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../property-metadata-and-configuration';
import { PropertyMetadata } from '../property-metadata';
import { getEntityName as importedGetEntityName } from '../game-designer-library.module';
import { SelectOption } from '../select-option';
import { NgIf } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { GameDesignerTypeComponent } from '../game-designer-type/game-designer-type.component';
import { JsonPipe } from '@angular/common';

/**
 * Represents a component that renders a single PropertyAndMetadata.
 */
@Component({
  selector: 'app-game-designer-property',
  templateUrl: './game-designer-property.component.html',
  styleUrls: ['./game-designer-property.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    JsonPipe,
    MatIconModule,
    GameDesignerTypeComponent
  ]
})
export class GameDesignerPropertyComponent {
  @Input({ required: true }) public propertyMetadataAndConfiguration!: PropertyMetadataAndConfiguration;
  @Input({ required: true }) public configuration!: Record<string, unknown>;
  @Input({ required: true }) public propertyMetadataMap!: Map<string, PropertyMetadata>;
  public showDebug: boolean = false;

  /***
   * Returns an entity name.  If the entity doesn't have a defined property name, the property key value will be returned.
   */
  public getEntityName(entity: any) {
    return importedGetEntityName(this.propertyMetadataAndConfiguration.propertyMetadata, entity);
  }

  public addEntity() {
    const newCollectionEntity: any[] = [];
    for (let index = 0; index < this.propertyMetadataAndConfiguration.propertyMetadata.associatedProperties!.length; index++) {
      const tuplePropertyMetadata: PropertyMetadata = this.propertyMetadataAndConfiguration!.propertyMetadata.associatedProperties![index];
      newCollectionEntity.push(tuplePropertyMetadata.defaultValue);
    }
    this.propertyMetadataAndConfiguration?.configuration.push(newCollectionEntity);
  }

  public deleteEntity(index: number) {
    this.propertyMetadataAndConfiguration.configuration.splice(index, 1);
  }

  /**
   * Creates a new PropertyMetadataAndConfiguration object from a child property metadata.  This is used by the game-designer-type component for recursion.
   * @param propertyMetadata
   * @returns
   */
  public createChild(childPropertyMetadata: PropertyMetadata): PropertyMetadataAndConfiguration {
    if (this.propertyMetadataAndConfiguration === null || this.propertyMetadataAndConfiguration === undefined) {
      throw new Error('propertyMetadataAndConfiguration is null or undefined');
    }

    return new PropertyMetadataAndConfiguration(childPropertyMetadata, this.propertyMetadataAndConfiguration.configuration);
  }
}
