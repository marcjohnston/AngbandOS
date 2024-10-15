import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../property-metadata-and-configuration';

@Component({
  selector: 'app-game-designer-type',
  templateUrl: './game-designer-type.component.html',
  styleUrls: ['./game-designer-type.component.scss']
})
export class GameDesignerTypeComponent implements OnInit {
  @Input() activeMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads it.

  constructor() { }

  ngOnInit(): void {
  }

}
