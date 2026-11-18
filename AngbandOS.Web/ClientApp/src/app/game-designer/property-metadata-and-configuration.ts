import { PropertyMetadata } from "./property-metadata";

/**
 * Represents the active metadata and configuration that is being presented to the user.
 */
export class PropertyMetadataAndConfiguration {
  /**
   * The entire configuration.  It cannot be null or undefined.
   */
  public configuration: any; // TODO: Any allows null and undefined.

  /**
   * Returns the property metadata that applies to the treenode.
   */
  public activePropertyMetadata: PropertyMetadata;

  /**
   * Returns the configuration that is applicable for the property metadata.  It cannot be null or undefined.
   */
  public activeConfiguration: any; // TODO: Any allows null and undefined.

  /**
   * Returns true, if the configuration is an array.  This is used to determine if the configuration is a collection or a single entry in the collection.
   */
  public get configurationIsArray() {
    return Array.isArray(this.activeConfiguration);
  }

  public get entityTitle(): string {
    return this.activeConfiguration[this.activePropertyMetadata.entityKeyPropertyName!]; // collectionKeyPropertyName was already verified in the json validation routine.
  }

  constructor(propertyMetadata: PropertyMetadata, activeConfiguration: any, configuration: any) {
    this.activePropertyMetadata = propertyMetadata;
    this.activeConfiguration = activeConfiguration;
    this.configuration = configuration;
  }
}
