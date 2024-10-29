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
  public defaultValue: any | null;
  public propertyMetadatas: PropertyMetadata[] | null;
  public dataTypes: PropertyMetadata[] | null;
  public keyPropertyName: string | null;
  public entityTitle: string | null;
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
              defaultValue: any | null,
              propertyMetadatas: PropertyMetadata[] | null,
              dataTypes: PropertyMetadata[] | null,
              keyPropertyName: string | null,
              entityTitle: string | null,
              foreignCollectionName: string | null) {
    this.type = type;
    this.title = title;
    this.propertyName = propertyName;
    this.categoryTitle = categoryTitle;
    this.isNullable = isNullable;
    this.description = description;
    this.defaultValue = defaultValue;
    this.propertyMetadatas = propertyMetadatas;
    this.dataTypes = dataTypes;
    this.keyPropertyName = keyPropertyName;
    this.entityTitle = entityTitle;
    this.foreignCollectionName = foreignCollectionName;
  }
}

