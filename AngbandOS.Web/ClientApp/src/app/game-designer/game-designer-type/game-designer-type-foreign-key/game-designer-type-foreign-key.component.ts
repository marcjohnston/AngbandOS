import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';

@Component({
  selector: 'app-game-designer-type-foreign-key',
  templateUrl: './game-designer-type-foreign-key.component.html',
  styleUrls: ['./game-designer-type-foreign-key.component.scss']
})
export class GameDesignerTypeForeignKeyComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  @Input() collections: Map<string, string[]> | undefined = undefined; // Undefined until Angular loads the parameters.
  @ViewChild('select') select!: ElementRef;
  public isNull: boolean | undefined;
  public unmodifiedValue: string | null | undefined = undefined;

  constructor() { }

  ngOnInit(): void {
    if (this.activePropertyMetadataAndConfiguration !== undefined) {
      this.isNull = this.activePropertyMetadataAndConfiguration.configuration[this.activePropertyMetadataAndConfiguration.propertyMetadata.propertyName] === null;
      this.unmodifiedValue = this.getValue();
    }
  }

  public undo() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.unmodifiedValue;
    this.isNull = this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] === null;
  }

  public getValue(): string | null {
    return this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName];
  }

  public setValue() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.isNull ? null : this.select.nativeElement.value;
  }
}
