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
import { MatIconModule } from '@angular/material/icon';
import { NgFor, NgIf } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { GameDesignerTypeEnumComponent } from './game-designer-type-enum/game-designer-type-enum.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-game-designer-type',
  templateUrl: './game-designer-type.component.html',
  styleUrls: ['./game-designer-type.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    NgFor,
    MatIconModule,
    MatSelectModule,
    GameDesignerTypeCharacterComponent,
    GameDesignerTypeIntegerComponent,
    GameDesignerTypeBooleanComponent,
    GameDesignerTypeColorComponent,
    GameDesignerTypeForeignKeyComponent,
    GameDesignerTypeTupleArrayComponent,
    GameDesignerTypeStringArrayComponent,
    GameDesignerTypeStringComponent,
    GameDesignerTypeEnumComponent
  ]
})
export class GameDesignerTypeComponent {
  @Input({ required: true }) public propertyMetadataAndConfiguration!: PropertyMetadataAndConfiguration;
  @Input({ required: true }) public configuration!: any;
  @Input({ required: true }) public propertyMetadataMap!: Map<string, PropertyMetadata>;

  /**
   * Creates a new PropertyMetadataAndConfiguration object from a child property metadata.  This is used by the game-designer-type component for recursion.
   * @param valueIndex
   * @returns
   */
  public createArrayChild(valueIndex: any): PropertyMetadataAndConfiguration {
    if (this.propertyMetadataAndConfiguration === undefined) {
      throw new Error("propertyMetadataAndConfiguration is undefined");
    }

    const validatedPropertyMetadataAndConfiguration = this.propertyMetadataAndConfiguration;
    const derivedArrayPropertyMetadata = new PropertyMetadata(
      validatedPropertyMetadataAndConfiguration.propertyMetadata.type,
      valueIndex, // This is how the serialization is naming the tuple fields
      validatedPropertyMetadataAndConfiguration.propertyMetadata.title,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.categoryTitle,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.labelIfNullable,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.description,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.defaultValue,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.propertyMetadatas,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.entityKeyPropertyName,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.entityNamePropertyName,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.entityNounTitle,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.entityNoun,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.foreignCollectionName,
      validatedPropertyMetadataAndConfiguration.propertyMetadata.enumOptions);
    const activePropertyMetadataAndConfiguration = validatedPropertyMetadataAndConfiguration.configuration[validatedPropertyMetadataAndConfiguration.propertyMetadata.propertyName];
    return new PropertyMetadataAndConfiguration(derivedArrayPropertyMetadata, activePropertyMetadataAndConfiguration);
  }

  public deleteArrayIndex(index: number) {
    this.propertyMetadataAndConfiguration!.configuration[this.propertyMetadataAndConfiguration!.propertyMetadata.propertyName].splice(index, 1);
  }

  public appendArrayItem() {
    this.propertyMetadataAndConfiguration!.configuration[this.propertyMetadataAndConfiguration!.propertyMetadata.propertyName].push("");
  }
}
