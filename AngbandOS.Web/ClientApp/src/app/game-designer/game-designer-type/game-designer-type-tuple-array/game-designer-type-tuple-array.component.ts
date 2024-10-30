import { Component, Input, OnInit } from '@angular/core';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { PropertyMetadata } from '../../property-metadata';

@Component({
  selector: 'app-game-designer-type-tuple-array',
  templateUrl: './game-designer-type-tuple-array.component.html',
  styleUrls: ['./game-designer-type-tuple-array.component.scss']
})
export class GameDesignerTypeTupleArrayComponent implements OnInit {
  @Input() activePropertyMetadataAndConfiguration: PropertyMetadataAndConfiguration | undefined = undefined; // Undefined until Angular loads it.

  constructor() { }

  ngOnInit(): void {
  }

  /**
   * Returns a new PropertyMetadataAndConfiguration object from a child property that references a tuple.
   * @param propertyMetadata
   * @param tupleIndex
   * @returns
   */
  public createTupleChild(tupleTypePropertyMetadata: PropertyMetadata, tupleIndex: number, tupleValues: any): PropertyMetadataAndConfiguration {
    const derivedTuplePropertyMetadata = new PropertyMetadata(
      tupleTypePropertyMetadata.type,
      `Item${tupleIndex + 1}`, // This is how the serialization is naming the tuple fields
      tupleTypePropertyMetadata.title,
      tupleTypePropertyMetadata.categoryTitle,
      tupleTypePropertyMetadata.isNullable,
      tupleTypePropertyMetadata.description,
      tupleTypePropertyMetadata.defaultValue,
      tupleTypePropertyMetadata.propertyMetadatas,
      tupleTypePropertyMetadata.keyPropertyName,
      tupleTypePropertyMetadata.entityTitle,
      tupleTypePropertyMetadata.foreignCollectionName);
    return new PropertyMetadataAndConfiguration(derivedTuplePropertyMetadata, tupleValues);
  }
}
