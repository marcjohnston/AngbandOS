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
  public defaultIntegerValue: number | null | undefined = undefined;
  public defaultBooleanValue: boolean | null | undefined = undefined;
  public defaultCharacterValue: string | null | undefined = undefined;
  public defaultStringValue: string | null | undefined = undefined;
  public defaultStringArrayValue: string[] | null | undefined = undefined;
  public collectionPropertyMetadatas: JsonPropertyMetadata[] | null | undefined = undefined;
  public tupleTypes: JsonPropertyMetadata[] | null | undefined = undefined;
  public collectionKeyPropertyName: string | null | undefined = undefined;
  public collectionEntityTitle: string | null | undefined = undefined;
  public foreignCollectionName: string | null | undefined = undefined;
}
