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
  public defaultValue: string[] | null | undefined = undefined;
  public propertyMetadatas: JsonPropertyMetadata[] | null | undefined = undefined;
  public entityKeyPropertyName: string | null | undefined = undefined;
  public entityNamePropertyName: string | null | undefined = undefined;
  public entityTitle: string | null | undefined = undefined;
  public foreignCollectionName: string | null | undefined = undefined;
}
