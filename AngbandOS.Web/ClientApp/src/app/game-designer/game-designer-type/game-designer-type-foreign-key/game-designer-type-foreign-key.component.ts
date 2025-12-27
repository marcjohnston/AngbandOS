import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { SelectOption } from '../../select-option';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-game-designer-type-foreign-key',
  templateUrl: './game-designer-type-foreign-key.component.html',
  styleUrls: ['./game-designer-type-foreign-key.component.scss'],
  standalone: true,
  imports: [
    NgFor,
    NgIf,
    FormsModule,
    MatIconModule
  ]
})
export class GameDesignerTypeForeignKeyComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads the parameters.
  @Input() collectionMap: Map<string, SelectOption[]> | undefined = undefined; // Undefined until Angular loads the parameters.
  @ViewChild('select') select!: ElementRef;
  public unmodifiedValue: string | null | undefined = undefined;
  public errorMessage: string = "";

  constructor() { }

  ngOnInit(): void {
    this.unmodifiedValue = this.getValue();
  }

  public undo() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.unmodifiedValue;
  }

  public getValue(): string | null {
    return this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] ?? "";
  }

  public setValue() {
    this.activePropertyMetadataAndConfiguration!.configuration[this.activePropertyMetadataAndConfiguration!.propertyMetadata.propertyName] = this.select.nativeElement.value == "" ? null : this.select.nativeElement.value;
  }
}
