import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { SelectOption } from '../../select-option';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  @Input() collectionMap: Map<string, SelectOption[]> | undefined = undefined; // Undefined until Angular loads the parameters.
  @ViewChild('select') select!: ElementRef;
  public unmodifiedValue: string | null | undefined = undefined;
  public errorMessage: string = "";

  constructor(
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.unmodifiedValue = this.getValue();

    const foreignCollectionName =
      this.activePropertyMetadataAndConfiguration?.propertyMetadata.foreignCollectionName;

    if (foreignCollectionName === null || foreignCollectionName === undefined) {
      this._snackBar.open(
        'The foreign-key metadata does not specify a foreign collection name.',
        '',
        { duration: 5000 }
      );
      return;
    }

    if (this.collectionMap === undefined || !this.collectionMap.has(foreignCollectionName)) {
      this._snackBar.open(
        `The foreign collection '${foreignCollectionName}' could not be found on the '${this.activePropertyMetadataAndConfiguration?.propertyMetadata.propertyName}' property.`,
        '',
        { duration: 5000 }
      );
      return;
    }
  }

  public undo() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.unmodifiedValue;
  }

  public getValue(): string | null {
    return this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] ?? "";
  }

  public setValue() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.select.nativeElement.value == "" ? null : this.select.nativeElement.value;
  }
}
