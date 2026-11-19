import { Component, Input, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { EnumOption } from "../../EnumOption";
import { PropertyMetadata } from '../../property-metadata';

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
  @Input({ required: true }) public configuration!: any;
  @Input({ required: true }) public propertyMetadataMap!: Map<string, PropertyMetadata>;

  public unmodifiedValue: number | null = null;

  public ngOnInit(): void {
    this.unmodifiedValue = this.getValue();
  }

  public get enumOptions(): EnumOption[] {
    return this.propertyMetadataAndConfiguration?.propertyMetadata.enumOptions ?? [];
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
