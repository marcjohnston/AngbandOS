import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';

@Component({
  selector: 'app-game-designer-type-string-array',
  templateUrl: './game-designer-type-string-array.component.html',
  styleUrls: ['./game-designer-type-string-array.component.scss']
})
export class GameDesignerTypeStringArrayComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads it.

  constructor() { }

  ngOnInit(): void {
  }

  public getValue(activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration): string {
    return activePropertyMetadataAndConfiguration.configuration.join('\n');
  }

  public setValue(activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration, event: any) {
    activePropertyMetadataAndConfiguration.configuration = event.target.value.split('\n');
  }
}
