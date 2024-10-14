import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadata } from '../property-metadata';
import { PropertyMetadataAndConfiguration } from '../property-metadata-and-configuration';

@Component({
  selector: 'app-game-designer-type',
  templateUrl: './game-designer-type.component.html',
  styleUrls: ['./game-designer-type.component.scss']
})
export class GameDesignerTypeComponent implements OnInit {
  @Input() activeMetadataAndConfiguration: PropertyMetadataAndConfiguration | null = null;

  constructor() { }

  ngOnInit(): void {
  }

}
