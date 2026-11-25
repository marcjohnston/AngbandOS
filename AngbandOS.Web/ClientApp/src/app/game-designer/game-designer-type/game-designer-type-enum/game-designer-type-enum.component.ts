import { Component, Input, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { PropertyMetadata } from '../../property-metadata';
import { SelectOption } from '../../select-option';

@Component({
  selector: 'app-game-designer-type-enum',
  templateUrl: './game-designer-type-enum.component.html',
  styleUrls: ['./game-designer-type-enum.component.scss'],
  standalone: true,
  imports: [
    NgFor,
    NgIf,
    FormsModule,
    MatIconModule
  ]
})
export class GameDesignerTypeEnumComponent implements OnInit {
  @Input({ required: true }) public propertyMetadataAndConfiguration!: PropertyMetadataAndConfiguration;
  @Input({ required: true }) public gameConfiguration!: Record<string, unknown>;
  @Input({ required: true }) public gamePropertyMetadata!: PropertyMetadata[];
  @Input({ required: true }) public enumMap!: Map<string, SelectOption[]>;
  public enumSelectOptions: SelectOption[] | undefined;
  public unmodifiedValue: number | null = null;

  public ngOnInit(): void {
    this.unmodifiedValue = this.getValue();
    if (this.propertyMetadataAndConfiguration.propertyMetadata.foreignCollectionName === null) {
      throw new Error("Enum cannot have a null foreign collection name.");
    }
    this.enumSelectOptions = this.enumMap.get(this.propertyMetadataAndConfiguration.propertyMetadata.foreignCollectionName);
  }

  public get enumOptions(): SelectOption[] {
    return []; // this.propertyMetadataAndConfiguration?.propertyMetadata.enumOptions ?? [];
  }

  public getValue(): number | null {
    const value =
      this.propertyMetadataAndConfiguration?.configuration[this.propertyMetadataAndConfiguration.propertyMetadata.propertyName];

    return value === null || value === undefined || value === "" ? null : Number(value);
  }

  public setValue(value: string): void {
    if (this.propertyMetadataAndConfiguration === undefined) {
      return;
    }

    this.propertyMetadataAndConfiguration.configuration[this.propertyMetadataAndConfiguration.propertyMetadata.propertyName] = value === "" ? null : Number(value);
  }

  public undo(): void {
    if (this.propertyMetadataAndConfiguration === undefined) {
      return;
    }

    this.propertyMetadataAndConfiguration.configuration[this.propertyMetadataAndConfiguration.propertyMetadata.propertyName] = this.unmodifiedValue;
  }
}
