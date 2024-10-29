/**
 * Represents a deserialized PropertyMetadata object that hasn't been validated.
 */

export class JsonPropertyMetadata {
  public type: string | undefined = undefined;
  public propertyName: string | undefined = undefined;
  public title: string | null | undefined = undefined;
  public categoryTitle: string | undefined = undefined;
  public isNullable: boolean | undefined = undefined;
  public description: string | null | undefined = undefined;
  public defaultValue: any | null | undefined = undefined;
  public propertyMetadatas: JsonPropertyMetadata[] | null | undefined = undefined;
  public dataTypes: JsonPropertyMetadata[] | null | undefined = undefined;
  public keyPropertyName: string | null | undefined = undefined;
  public entityTitle: string | null | undefined = undefined;
  public foreignCollectionName: string | null | undefined = undefined;
}
