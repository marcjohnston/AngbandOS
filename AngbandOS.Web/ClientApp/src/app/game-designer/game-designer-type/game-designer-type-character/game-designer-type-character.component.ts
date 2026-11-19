import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PropertyMetadata } from '../../property-metadata';

@Component({
  selector: 'app-game-designer-type-character',
  templateUrl: './game-designer-type-character.component.html',
  styleUrls: ['./game-designer-type-character.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    FormsModule
  ]
})
export class GameDesignerTypeCharacterComponent {
  @Input({ required: true }) public propertyMetadataAndConfiguration!: PropertyMetadataAndConfiguration;
}
