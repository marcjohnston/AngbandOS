import { Component, Input, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { EnumOption } from '../../property-metadata';

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
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined;

  public unmodifiedValue: number | null = null;

  public ngOnInit(): void {
    this.unmodifiedValue = this.getValue();
  }

  public get options(): EnumOption[] {
    return this.activePropertyMetadataAndConfiguration?.propertyMetadata.enumOptions ?? [];
  }

  public getValue(): number | null {
    const value =
      this.activePropertyMetadataAndConfiguration
        ?.configuration[this.activePropertyMetadataAndConfiguration.propertyMetadata.propertyName];

    return value === null || value === undefined || value === ""
      ? null
      : Number(value);
  }

  public setValue(value: string): void {
    if (this.activePropertyMetadataAndConfiguration === undefined) {
      return;
    }

    this.activePropertyMetadataAndConfiguration.configuration[
      this.activePropertyMetadataAndConfiguration.propertyMetadata.propertyName] =
      value === ""
        ? null
        : Number(value);
  }

  public undo(): void {
    if (this.activePropertyMetadataAndConfiguration === undefined) {
      return;
    }

    this.activePropertyMetadataAndConfiguration.configuration[
      this.activePropertyMetadataAndConfiguration.propertyMetadata.propertyName] =
      this.unmodifiedValue;
  }
}
