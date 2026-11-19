import { PropertyMetadata } from "./property-metadata";

/**
 * Represents the metadata and configuration that is being presented to the user.  This class glues both structures together with some additional
 * helper methods because these objects are ties to tree nodes as a single object.
 */
export class PropertyMetadataAndConfiguration {
  /**
   * Returns the property metadata that applies to the treenode.
   */
  public propertyMetadata: PropertyMetadata;

  /**
   * Returns the configuration that is applicable for the property metadata.  It cannot be null or undefined.
   */
  public configuration: any; // TODO: Any allows null and undefined.

  /**
   * Returns true, if the configuration is an array.  This is used to determine if the configuration is a collection or a single entry in the collection.
   */
  public get configurationIsArray() {
    return Array.isArray(this.configuration);
  }

  public get entityTitle(): string {
    return this.configuration[this.propertyMetadata.entityKeyPropertyName!]; // collectionKeyPropertyName was already verified in the json validation routine.
  }

  constructor(propertyMetadata: PropertyMetadata, configuration: any) {
    this.propertyMetadata = propertyMetadata;
    this.configuration = configuration;
  }
}
