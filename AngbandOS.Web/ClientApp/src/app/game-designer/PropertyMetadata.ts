export class PropertyMetadata {
  public type: string | undefined = undefined;
  public propertyName: string | undefined = undefined;
  public title: string | null | undefined = undefined;
  public categoryTitle: string | undefined = undefined;
  public isNullable: boolean | undefined = undefined;
  public isArray: boolean | undefined = undefined;
  public description: string | null | undefined = undefined;
  public defaultIntegerValue: number | null | undefined = undefined;
  public defaultBooleanValue: boolean | null | undefined = undefined;
  public defaultCharacterValue: string | null | undefined = undefined;
  public defaultStringValue: string | null | undefined = undefined;
  public collectionPropertiesMetadata: PropertyMetadata[] | null | undefined = undefined;
  public tupleTypes: PropertyMetadata[] | null | undefined = undefined;
  public collectionKeyPropertyName: string | null | undefined = undefined;
}
