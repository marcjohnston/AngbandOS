import { PropertyMetadata } from "./property-metadata";

/**
 * Represents the active metadata and configuration that is being presented to the user.
 */
export class PropertyMetadataAndConfiguration {
  public propertyMetadata: PropertyMetadata;

  /**
   * Returns the configuration that is applicable for the property metadata or null, when there is no applicable configuration.  This may occur when the user selects a collection root node and not
   * an entity belonging to the collection.  The UI will then render details about the collection and not an entity.
   */
  public configuration: any | null;

  public get collectionTitle(): string {
    return this.propertyMetadata.collectionEntityTitle ?? this.propertyMetadata.renderTitle;
  }

  public get collectionEntityTitle(): string {
    return this.configuration[this.propertyMetadata.collectionKeyPropertyName!]; // This was already verified in the json validation routine.
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

  constructor(propertyMetadata: PropertyMetadata, configuration: any | null) {
    this.propertyMetadata = propertyMetadata;
    this.configuration = configuration;
  }
}
