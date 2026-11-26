import { getEntityName as importedGetEntityName } from '../../game-designer-library.module';
import { Component, Input } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { PropertyMetadata } from '../../property-metadata';
import { SelectOption } from '../../select-option';
import { NgFor } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-game-designer-property-collection',
  templateUrl: './game-designer-property-collection.component.html',
  styleUrl: './game-designer-property-collection.component.scss',
  imports: [
    MatIconModule
  ]
})
export class GameDesignerPropertyCollectionComponent {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  @Input() collectionMap: Map<string, SelectOption[]> | undefined = undefined; // Undefined until Angular loads the parameters.


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
}
