import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PropertyMetadata } from '../../property-metadata';

@Component({
  selector: 'app-game-designer-type-string-array',
  templateUrl: './game-designer-type-string-array.component.html',
  styleUrls: ['./game-designer-type-string-array.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    FormsModule
  ]
})
export class GameDesignerTypeStringArrayComponent {
  @Input({ required: true }) public propertyMetadataAndConfiguration!: PropertyMetadataAndConfiguration;

  public getValue(propertyMetadataAndConfiguration: PropertyMetadataAndConfiguration): string {
    return propertyMetadataAndConfiguration.configuration[propertyMetadataAndConfiguration.propertyMetadata.propertyName].join('\n');
  }

  public setValue(propertyMetadataAndConfiguration: PropertyMetadataAndConfiguration, event: any) {
    propertyMetadataAndConfiguration.configuration[propertyMetadataAndConfiguration.propertyMetadata.propertyName] = event.target.value.split('\n');
  }
}
