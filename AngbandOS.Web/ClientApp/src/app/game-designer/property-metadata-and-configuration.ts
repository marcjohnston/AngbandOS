import { PropertyMetadata } from "./property-metadata";

/**
 * Represents the active metadata and configuration that is being presented to the user.
 */
export class PropertyMetadataAndConfiguration {
  public propertyMetadata: PropertyMetadata;
  public configuration: any | null;

  public get collectionTitle(): string {
    return this.propertyMetadata.collectionEntityTitle ?? this.propertyMetadata.renderTitle;
  }

  public get collectionEntityTitle(): string {
    return this.configuration[this.propertyMetadata.collectionKeyPropertyName!]; // This was already verified in the json validation routine.
  }
  constructor(propertyMetadata: PropertyMetadata, configuration: any | null) {
    this.propertyMetadata = propertyMetadata;
    this.configuration = configuration;
  }
}
