import { PropertyMetadata } from "./property-metadata";

/**
 * Represents the active metadata and configuration that is being presented to the user.
 */
export class PropertyMetadataAndConfiguration {
  /**
   * Returns the property metadata that applies to the treenode.
   */
  public propertyMetadata: PropertyMetadata;

  /**
   * Returns the configuration that is applicable for the property metadata or null, when there is no applicable configuration.  This may occur when the user selects a collection root node and not
   * an entity belonging to the collection.  The UI will then render details about the collection and not an entity.
   */
  public configuration: any | null;

  public get collectionEntityTitle(): string {
    return this.configuration[this.propertyMetadata.collectionKeyPropertyName!]; // collectionKeyPropertyName was already verified in the json validation routine.
  }

  public getTextArea(propertyName: string): string {
    return this.configuration[propertyName].join('\n');
  }

  public setTextArea(propertyName: string, event: any) {
    this.configuration[propertyName] = event.target.value.split('\n');
  }

  /**
   * Creates a new PropertyMetadataAndConfiguration object from a child property metadata.  This is used by the game-designer-type component for recursion.
   * @param propertyMetadata
   * @returns
   */
  public createChild(propertyMetadata: PropertyMetadata): PropertyMetadataAndConfiguration {
    return new PropertyMetadataAndConfiguration(propertyMetadata, this.configuration);
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
      tupleTypePropertyMetadata.isArray,
      tupleTypePropertyMetadata.description,
      tupleTypePropertyMetadata.defaultIntegerValue,
      tupleTypePropertyMetadata.defaultBooleanValue,
      tupleTypePropertyMetadata.defaultCharacterValue,
      tupleTypePropertyMetadata.defaultStringValue,
      tupleTypePropertyMetadata.collectionPropertyMetadatas,
      tupleTypePropertyMetadata.tupleTypes,
      tupleTypePropertyMetadata.collectionKeyPropertyName,
      tupleTypePropertyMetadata.collectionEntityTitle);
    return new PropertyMetadataAndConfiguration(derivedTuplePropertyMetadata, tupleValues);
  }

  constructor(propertyMetadata: PropertyMetadata, configuration: any | null) {
    this.propertyMetadata = propertyMetadata;
    this.configuration = configuration;
  }
}
