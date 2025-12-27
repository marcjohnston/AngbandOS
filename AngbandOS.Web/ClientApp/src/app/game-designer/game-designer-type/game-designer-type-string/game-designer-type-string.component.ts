import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

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
export class GameDesignerTypeStringComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads it.

  constructor() { }

  ngOnInit(): void {
  }

}
