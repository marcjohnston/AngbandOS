/**
 * Represents a validated PropertyMetadata object.
 */
export class PropertyMetadata {
  public type: string;
  public propertyName: string;
  public title: string | null;
  public categoryTitle: string;
  public description: string | null;
  public defaultValue: string[] | null;
  public associatedProperties: PropertyMetadata[] | null;
  public entityKeyPropertyName: string | null;
  public entityNamePropertyName: string | null;
  public entityNounTitle: string | null;
  public foreignCollectionName: string | null;
  public labelIfNullable: string | null;

  /**
   * Returns the title of property.
   */
  public get renderTitle(): string {
    return this.title ?? this.propertyName;
  }

  constructor(type: string,
      propertyName: string,
      title: string | null,
      categoryTitle: string,
      labelIfNullable: string | null,
      description: string | null,
      defaultValue: string[] | null,
      associatedProperties: PropertyMetadata[] | null,
      entityKeyPropertyName: string | null,
      entityNamePropertyName: string | null,
      entityNounTitle: string | null,
      foreignCollectionName: string | null) {
    this.type = type;
    this.title = title;
    this.propertyName = propertyName;
    this.categoryTitle = categoryTitle;
    this.labelIfNullable = labelIfNullable;
    this.description = description;
    this.defaultValue = defaultValue;
    this.associatedProperties = associatedProperties;
    this.entityKeyPropertyName = entityKeyPropertyName;
    this.entityNamePropertyName = entityNamePropertyName;
    this.entityNounTitle = entityNounTitle;
    this.foreignCollectionName = foreignCollectionName;
  }
}

