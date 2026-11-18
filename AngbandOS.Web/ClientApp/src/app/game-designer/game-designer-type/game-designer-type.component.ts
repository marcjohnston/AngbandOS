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
export class GameDesignerTypeComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  constructor(
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
  }

  /**
   * Creates a new PropertyMetadataAndConfiguration object from a child property metadata.  This is used by the game-designer-type component for recursion.
   * @param activePropertyMetadataAndConfiguration - We pass this in from the HTML because we know it is not undefined.
   * @param valueIndex
   * @returns
   */
  public createArrayChild(valueIndex: any) {
    if (this.activePropertyMetadataAndConfiguration === undefined) {
      this._snackBar.open('Property metadata and configuration are not defined');
      return;
    }

    const validatedActivePropertyMetadataAndConfiguration = this.activePropertyMetadataAndConfiguration;
    const derivedArrayPropertyMetadata = new PropertyMetadata(
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.type,
      valueIndex, // This is how the serialization is naming the tuple fields
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.title,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.categoryTitle,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.labelIfNullable,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.description,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.defaultValue,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.propertyMetadatas,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.entityKeyPropertyName,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.entityNamePropertyName,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.entityNounTitle,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.entityNoun,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.foreignCollectionName,
      validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.enumOptions);
    const activePropertyMetadataAndConfiguration = validatedActivePropertyMetadataAndConfiguration.activeConfiguration[validatedActivePropertyMetadataAndConfiguration.activePropertyMetadata.propertyName];
    return new PropertyMetadataAndConfiguration(derivedArrayPropertyMetadata, activePropertyMetadataAndConfiguration, validatedActivePropertyMetadataAndConfiguration.configuration);
  }

  public deleteArrayIndex(index: number) {
    this.activePropertyMetadataAndConfiguration!.activeConfiguration[this.activePropertyMetadataAndConfiguration!.activePropertyMetadata.propertyName].splice(index, 1);
  }

  public appendArrayItem() {
    //this.activePropertyMetadataAndConfiguration!.propertyMetadata.def
    this.activePropertyMetadataAndConfiguration!.activeConfiguration[this.activePropertyMetadataAndConfiguration!.activePropertyMetadata.propertyName].push("");
  }
}
