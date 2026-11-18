import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { SelectOption } from '../../select-option';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { getEntityName as importedGetEntityName } from '../../game-designer-library.module';

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
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  @ViewChild('select') select!: ElementRef;

  public selectOptions: SelectOption[] | null = null; // Undefined until it is built during the ngInit.
  public unmodifiedValue: string | null | undefined = undefined;
  public errorMessage: string = "";

  constructor(
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    // Validate that the activePropertyMetadataAndConfiguration was passed in.
    if (this.activePropertyMetadataAndConfiguration === null || this.activePropertyMetadataAndConfiguration === undefined) {
      // This is a developer error, so throw an exception.
      throw new Error("The activePropertyMetadataAndConfiguration parameter was not passed into the GameDesignerTypeForeignKeyComponent.");
    }

    this.unmodifiedValue = this.getValue();

    const foreignCollectionName = this.activePropertyMetadataAndConfiguration.activePropertyMetadata.foreignCollectionName;

    if (foreignCollectionName === null || foreignCollectionName === undefined) {
      this._snackBar.open(
        'The foreign-key metadata does not specify a foreign collection name.',
        '',
        { duration: 5000 }
      );
      return;
    }

    const foreignCollection = this.activePropertyMetadataAndConfiguration.configuration[foreignCollectionName];
    if (foreignCollection === null || foreignCollection === undefined) {
      this._snackBar.open(
        `The foreign collection '${foreignCollectionName}' could not be found on the '${this.activePropertyMetadataAndConfiguration?.activePropertyMetadata.propertyName}' property.`,
        '',
        { duration: 5000 }
      );
      return;
    }

    // Generate the foreign keys for the foreign collection.
    for (const foreignEntity of foreignCollection) {
      // Get the key value for the entity.
      const keyValue = foreignEntity[this.activePropertyMetadataAndConfiguration.activeConfiguration.entityKeyPropertyName!]; // collectionKeyPropertyName was already validated.

      // Now generate the entity name for the tree node title.
      const entityName = importedGetEntityName(this.activePropertyMetadataAndConfiguration.activePropertyMetadata, foreignEntity);

      const selectOption = new SelectOption(entityName, keyValue)
      this.selectOptions?.push(selectOption);
    }
  }

  public undo() {
    this.activePropertyMetadataAndConfiguration!.activeConfiguration[this.activePropertyMetadataAndConfiguration!.activePropertyMetadata.propertyName] = this.unmodifiedValue;
  }

  public getValue(): string | null {
    return this.activePropertyMetadataAndConfiguration!.activeConfiguration[this.activePropertyMetadataAndConfiguration!.activePropertyMetadata.propertyName] ?? "";
  }

  public setValue() {
    this.activePropertyMetadataAndConfiguration!.activeConfiguration[this.activePropertyMetadataAndConfiguration!.activePropertyMetadata.propertyName] = this.select.nativeElement.value == "" ? null : this.select.nativeElement.value;
  }
}
