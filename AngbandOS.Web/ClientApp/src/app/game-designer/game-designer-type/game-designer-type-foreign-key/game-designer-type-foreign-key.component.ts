import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { SelectOption } from '../../select-option';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { getEntityName as importedGetEntityName } from '../../game-designer-library.module';
import { PropertyMetadata } from '../../property-metadata';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-game-designer-type-foreign-key',
  templateUrl: './game-designer-type-foreign-key.component.html',
  styleUrls: ['./game-designer-type-foreign-key.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    JsonPipe,
    FormsModule,
    MatIconModule
  ]
})
export class GameDesignerTypeForeignKeyComponent implements OnInit {
  @Input({ required: true }) public propertyMetadataAndConfiguration!: PropertyMetadataAndConfiguration;
  @Input({ required: true }) public configuration!: Record<string, unknown>;
  @Input({ required: true }) public propertyMetadataMap!: Map<string, PropertyMetadata>;
  @ViewChild('select') select!: ElementRef;
  public showDebug: boolean = false;

  public selectOptions: SelectOption[] = [];
  public unmodifiedValue: string | null | undefined = undefined;

  ngOnInit(): void {
    this.unmodifiedValue = this.getValue();

    const foreignCollectionName = this.propertyMetadataAndConfiguration.propertyMetadata.foreignCollectionName;

    // The foreign collection name must be present.
    if (foreignCollectionName === null) {
      throw new Error('The foreign-key metadata does not specify a foreign collection name.');
    }

    // Track for an error where no collections exist.
    let collectionFound = false;

    // A foreign collection can be represented by multiple metadata entries.
    for (const foreignCollectionPropertyMetadata of this.propertyMetadataMap.values()) {
      // Check to see if the foreign collection name matches.
      if (foreignCollectionPropertyMetadata.foreignCollectionName !== foreignCollectionName) {
        continue;
      }

      // It does.  Validate the collection.
      const foreignCollection: unknown = this.configuration[foreignCollectionPropertyMetadata.propertyName];
      if (!Array.isArray(foreignCollection)) {
        continue;
      }

      // Prevent the no collection found error from being thrown.
      collectionFound = true;

      // Generate the select options for the foreign collection.
      for (const foreignEntity of foreignCollection) {
        // Get the key value for the entity.
        const keyValue = foreignEntity[foreignCollectionPropertyMetadata.entityKeyPropertyName!];

        // Now generate the entity name for the tree node title.
        const entityName = importedGetEntityName(foreignCollectionPropertyMetadata, foreignEntity);

        const selectOption = new SelectOption(entityName, keyValue)
        this.selectOptions.push(selectOption);
      }
    }

    if (!collectionFound) {
      throw new Error(`No collections found for '${foreignCollectionName}'.`);
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
