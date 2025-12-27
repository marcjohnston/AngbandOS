import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../property-metadata-and-configuration';
import { PropertyMetadata } from '../property-metadata';
import { SelectOption } from '../select-option';
import { GameDesignerTypeCharacterComponent } from './game-designer-type-character/game-designer-type-character.component';
import { GameDesignerTypeIntegerComponent } from './game-designer-type-integer/game-designer-type-integer.component';
import { GameDesignerTypeBooleanComponent } from './game-designer-type-boolean/game-designer-type-boolean.component';
import { GameDesignerTypeColorComponent } from './game-designer-type-color/game-designer-type-color.component';
import { GameDesignerTypeForeignKeyComponent } from './game-designer-type-foreign-key/game-designer-type-foreign-key.component';
import { GameDesignerTypeTupleArrayComponent } from './game-designer-type-tuple-array/game-designer-type-tuple-array.component';
import { GameDesignerTypeStringArrayComponent } from './game-designer-type-string-array/game-designer-type-string-array.component';
import { GameDesignerTypeStringComponent } from './game-designer-type-string/game-designer-type-string.component';
import { MatIcon } from '@angular/material/icon';
import { NgFor, NgIf } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-game-designer-type',
  templateUrl: './game-designer-type.component.html',
  styleUrls: ['./game-designer-type.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    NgFor,
    MatIcon,
    MatSelectModule,
    GameDesignerTypeCharacterComponent,
    GameDesignerTypeIntegerComponent,
    GameDesignerTypeBooleanComponent,
    GameDesignerTypeColorComponent,
    GameDesignerTypeForeignKeyComponent,
    GameDesignerTypeTupleArrayComponent,
    GameDesignerTypeStringArrayComponent,
    GameDesignerTypeStringComponent
  ]
})
export class GameDesignerTypeComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  @Input() collectionMap: Map<string, SelectOption[]> | undefined = undefined; // Undefined until Angular loads the parameters.

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
      activePropertyMetadataAndConfiguration.propertyMetadata.entityKeyPropertyName,
      activePropertyMetadataAndConfiguration.propertyMetadata.entityNamePropertyName,
      activePropertyMetadataAndConfiguration.propertyMetadata.entityNounTitle,
      activePropertyMetadataAndConfiguration.propertyMetadata.entityNoun,
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
