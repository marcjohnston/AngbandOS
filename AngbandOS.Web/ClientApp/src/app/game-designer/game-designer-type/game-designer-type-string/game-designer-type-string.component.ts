import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PropertyMetadata } from '../../property-metadata';

@Component({
  selector: 'app-game-designer-type-string',
  templateUrl: './game-designer-type-string.component.html',
  styleUrls: ['./game-designer-type-string.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    FormsModule
  ]
})
export class GameDesignerTypeStringComponent {
  @Input({ required: true }) public propertyMetadataAndConfiguration!: PropertyMetadataAndConfiguration;
}
