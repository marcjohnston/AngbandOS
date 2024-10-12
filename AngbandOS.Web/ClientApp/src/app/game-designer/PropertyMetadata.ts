export class PropertyMetadata {
    public type: string | null = null;
    public propertyName: string | null = null;
    public title: string | null = null;
    public categoryTitle: string | null = null;
    public isNullable: boolean | null = null;
    public isArray: boolean | null = null;
    public description: string | null = null;
    public defaultIntegerValue: number | null = null;
    public defaultBooleanValue: boolean | null = null;
    public defaultCharacterValue: string | null = null;
    public defaultStringValue: string | null = null;
    public collectionPropertiesMetadata: PropertyMetadata[] | null = null;
    public tupleTypes: PropertyMetadata[] | null = null;
}
