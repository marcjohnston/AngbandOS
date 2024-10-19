import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';

@Component({
  selector: 'app-game-designer-type-boolean',
  templateUrl: './game-designer-type-boolean.component.html',
  styleUrls: ['./game-designer-type-boolean.component.scss']
})
export class GameDesignerTypeBooleanComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads it.
  @ViewChild('select') select!: ElementRef;
  public unmodifiedValue: string | undefined = undefined; // The possible values will be true, false or "" to represent null.

  constructor() { }

  ngOnInit(): void {
    this.unmodifiedValue = this.getValue();
  }

  /**
   * Returns the current value of the configuration.
   * @returns "true", "false" or "" for null
   */
  public getValue(): string {
    return this.activePropertyMetadataAndConfiguration!.configuration ?? "";
  }

  public setValue() {
    this.activePropertyMetadataAndConfiguration!.configuration = this.select.nativeElement.value === "" ? null : this.select.nativeElement.value === "true" ? true : false;
  }

  public undo() {
    this.activePropertyMetadataAndConfiguration!.configuration = this.unmodifiedValue;
  }
}
