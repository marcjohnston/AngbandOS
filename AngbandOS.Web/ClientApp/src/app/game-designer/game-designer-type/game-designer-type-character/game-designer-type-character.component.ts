import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-game-designer-type-character',
  templateUrl: './game-designer-type-character.component.html',
  styleUrls: ['./game-designer-type-character.component.scss'],
  standalone: true,
  imports: [
    FormsModule
  ]
})
export class GameDesignerTypeCharacterComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads it.

  constructor() { }

  ngOnInit(): void {
  }

}
