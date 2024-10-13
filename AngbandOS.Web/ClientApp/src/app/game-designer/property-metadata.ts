/**
 * Represents a validated PropertyMetadata object.
 */
export class PropertyMetadata {
  public type: string;
  public propertyName: string;
  public title: string | null;
  public categoryTitle: string;
  public isNullable: boolean;
  public isArray: boolean;
  public description: string | null;
  public defaultIntegerValue: number | null;
  public defaultBooleanValue: boolean | null;
  public defaultCharacterValue: string | null;
  public defaultStringValue: string | null;
  public collectionPropertiesMetadata: PropertyMetadata[] | null;
  public tupleTypes: PropertyMetadata[] | null;
  public collectionKeyPropertyName: string | null;
  public collectionEntityTitle: string | null;

  /**
   * Returns the title of property.
   */
  public get renderTitle(): string {
    // If the title is null, we render the property name.
    return this.title ?? this.propertyName;
  }

  constructor(type: string,
              propertyName: string,
              title: string | null,
              categoryTitle: string,
              isNullable: boolean,
              isArray: boolean,
              description: string | null,
              defaultIntegerValue: number | null,
              defaultBooleanValue: boolean | null,
              defaultCharacterValue: string | null,
              defaultStringValue: string | null,
              collectionPropertiesMetadata: PropertyMetadata[] | null,
              tupleTypes: PropertyMetadata[] | null,
              collectionKeyPropertyName: string | null,
              collectionEntityTitle: string | null) {
    this.type = type;
    this.title = title;
    this.propertyName = propertyName;
    this.categoryTitle = categoryTitle;
    this.isNullable = isNullable;
    this.isArray = isArray;
    this.description = description;
    this.defaultIntegerValue = defaultIntegerValue;
    this.defaultBooleanValue = defaultBooleanValue;
    this.defaultCharacterValue = defaultCharacterValue;
    this.defaultStringValue = defaultStringValue;
    this.collectionPropertiesMetadata = collectionPropertiesMetadata;
    this.tupleTypes = tupleTypes;
    this.collectionKeyPropertyName = collectionKeyPropertyName;
    this.collectionEntityTitle = collectionEntityTitle;
  }
}

