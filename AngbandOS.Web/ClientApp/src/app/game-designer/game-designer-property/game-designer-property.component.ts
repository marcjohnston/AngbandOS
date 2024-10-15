import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../property-metadata-and-configuration';

@Component({
  selector: 'app-game-designer-property',
  templateUrl: './game-designer-property.component.html',
  styleUrls: ['./game-designer-property.component.scss']
})
export class GameDesignerPropertyComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads it.

  constructor() { }

  ngOnInit(): void {
  }

}
