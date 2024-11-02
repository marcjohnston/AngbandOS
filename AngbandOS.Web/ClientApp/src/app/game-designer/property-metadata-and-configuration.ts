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

  /**
   * Returns true, if the configuration is an array.  This is used to determine if the configuration is a collection or a single entry in the collection.
   */
  public get configurationIsArray() {
    return Array.isArray(this.configuration);
  }

  public get entityTitle(): string {
    return this.configuration[this.propertyMetadata.keyPropertyName!]; // collectionKeyPropertyName was already verified in the json validation routine.
  }

  constructor(propertyMetadata: PropertyMetadata, configuration: any | null) {
    this.propertyMetadata = propertyMetadata;
    this.configuration = configuration;
  }
}
