import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { SelectOption } from '../../select-option';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { getEntityName, getEntityName as importedGetEntityName } from '../../game-designer-library.module';
import { PropertyMetadata } from '../../property-metadata';

@Component({
  selector: 'app-game-designer-type-foreign-key',
  templateUrl: './game-designer-type-foreign-key.component.html',
  styleUrls: ['./game-designer-type-foreign-key.component.scss'],
  standalone: true,
  imports: [
    NgFor,
    NgIf,
    FormsModule,
    MatIconModule
  ]
})
export class GameDesignerTypeForeignKeyComponent implements OnInit {
  @Input({ required: true }) public propertyMetadataAndConfiguration!: PropertyMetadataAndConfiguration;
  @Input({ required: true }) public configuration!: Record<string, unknown>;
  @Input({ required: true }) public propertyMetadataMap!: Map<string, PropertyMetadata>;
  @ViewChild('select') select!: ElementRef;

  public selectOptions: SelectOption[] = [];
  public unmodifiedValue: string | null | undefined = undefined;
  public errorMessage: string = "";

  constructor(
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.unmodifiedValue = this.getValue();

    const foreignCollectionName = this.propertyMetadataAndConfiguration.propertyMetadata.foreignCollectionName;

    if (foreignCollectionName === null || foreignCollectionName === undefined) {
      this._snackBar.open(
        'The foreign-key metadata does not specify a foreign collection name.',
        '',
        { duration: 5000 }
      );
      return;
    }

    const foreignCollection: unknown = this.configuration[foreignCollectionName];
    if (!Array.isArray(foreignCollection)) {
      this._snackBar.open(
        `The foreign collection '${foreignCollectionName}' could not be found on the '${this.propertyMetadataAndConfiguration?.propertyMetadata.propertyName}' property.`,
        '',
        { duration: 5000 }
      );
      return;
    }

    // We need to retrieve the propertyMetadata for the foreign collection.
    const foreignCollectionPropertyMetadata: PropertyMetadata | undefined = this.propertyMetadataMap.get(foreignCollectionName);

    // Validate it.
    if (foreignCollectionPropertyMetadata === undefined) {
      throw new Error(`PropertyMetadataMap does not have item for ${foreignCollectionName}`);
    }

    // Generate the foreign keys for the foreign collection.
    for (const foreignEntity of foreignCollection) {
      // Get the key value for the entity.
      const keyValue = foreignEntity[foreignCollectionPropertyMetadata.entityKeyPropertyName!]; // collectionKeyPropertyName was already validated.

      // Now generate the entity name for the tree node title.
      const entityName = importedGetEntityName(foreignCollectionPropertyMetadata, foreignEntity);

      const selectOption = new SelectOption(entityName, keyValue)
      this.selectOptions.push(selectOption);
    }
  }

  public undo() {
    this.propertyMetadataAndConfiguration!.configuration[this.propertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.unmodifiedValue;
  }

  public getValue(): string | null {
    return this.propertyMetadataAndConfiguration!.configuration[this.propertyMetadataAndConfiguration!.propertyMetadata.propertyName] ?? "";
  }

  public setValue() {
    this.propertyMetadataAndConfiguration!.configuration[this.propertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.select.nativeElement.value == "" ? null : this.select.nativeElement.value;
  }
}
