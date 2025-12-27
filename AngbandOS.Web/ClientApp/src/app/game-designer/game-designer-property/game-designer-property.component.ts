import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../property-metadata-and-configuration';
import { PropertyMetadata } from '../property-metadata';
import { getEntityName as importedGetEntityName } from '../game-designer-library.module';
import { SelectOption } from '../select-option';
import { NgFor, NgIf } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { GameDesignerTypeComponent } from '../game-designer-type/game-designer-type.component';

@Component({
  selector: 'app-game-designer-property',
  templateUrl: './game-designer-property.component.html',
  styleUrls: ['./game-designer-property.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    NgFor,
    MatIconModule,
    GameDesignerTypeComponent
  ]
})
export class GameDesignerPropertyComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  @Input() collectionMap: Map<string, SelectOption[]> | undefined = undefined; // Undefined until Angular loads the parameters.

  constructor() { }

  ngOnInit(): void {
  }

  /***
   * Returns an entity name.  If the entity doesn't have a defined property name, the property key value will be returned.
   */
  public getEntityName(entity: any) {
    return importedGetEntityName(this.activePropertyMetadataAndConfiguration!.propertyMetadata, entity);
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
