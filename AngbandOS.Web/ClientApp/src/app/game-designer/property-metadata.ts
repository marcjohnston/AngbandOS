/**
 * Represents a validated PropertyMetadata object.
 */
export class PropertyMetadata {
  public type: string;
  public propertyName: string;
  public title: string | null;
  public categoryTitle: string;
  public isNullable: boolean;
  public description: string | null;
  public defaultValue: string[] | null;
  public propertyMetadatas: PropertyMetadata[] | null;
  public entityKeyPropertyName: string | null;
  public entityNamePropertyName: string | null;
  public entityNounTitle: string | null;
  public entityNoun: string | null;
  public foreignCollectionName: string | null;

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
              description: string | null,
              defaultValue: string[] | null,
              propertyMetadatas: PropertyMetadata[] | null,
              entityKeyPropertyName: string | null,
              entityNamePropertyName: string | null,
              entityNounTitle: string | null,
              entityNoun: string | null,
              foreignCollectionName: string | null) {
    this.type = type;
    this.title = title;
    this.propertyName = propertyName;
    this.categoryTitle = categoryTitle;
    this.isNullable = isNullable;
    this.description = description;
    this.defaultValue = defaultValue;
    this.propertyMetadatas = propertyMetadatas;
    this.entityKeyPropertyName = entityKeyPropertyName;
    this.entityNamePropertyName = entityNamePropertyName;
    this.entityNounTitle = entityNounTitle;
    this.entityNoun = entityNoun;
    this.foreignCollectionName = foreignCollectionName;
  }
}

