import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { NgIf } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-game-designer-type-boolean',
  templateUrl: './game-designer-type-boolean.component.html',
  styleUrls: ['./game-designer-type-boolean.component.scss'],
  standalone: true,
  imports: [
    NgIf,
    MatSelectModule,
    MatIconModule,
    FormsModule
  ]
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
    return this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] ?? "";
  }

  public setValue() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.select.nativeElement.value === "" ? null : this.select.nativeElement.value === "true" ? true : false;
  }

  public undo() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.unmodifiedValue;
  }
}
