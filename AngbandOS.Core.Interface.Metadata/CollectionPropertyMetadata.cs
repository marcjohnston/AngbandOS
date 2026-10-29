namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents a property that is a collection of entities.
/// </summary>
public class CollectionPropertyMetadata : PropertyMetadata
{
    public CollectionPropertyMetadata(string propertyName) : base("collection", propertyName) { }

    /// <summary>
    /// Represents the metadata for the properties of the entities in the collection.
    /// </summary>
    public new PropertyMetadata[]? PropertyMetadatas
    {
        get => base.PropertyMetadatas;
        set => base.PropertyMetadatas = value;
    }

    /// <summary>
    /// Represents the noun that describes the entities in the collection.
    /// </summary>
    public new string? EntityNoun
    {
        get => base.EntityNoun;
        set => base.EntityNoun = value;
    }
    
    /// <summary>
    /// Represents the title of the noun that describes the entities in the collection.
    /// </summary>
    public new string? EntityNounTitle
    {
        get => base.EntityNounTitle;
        set => base.EntityNounTitle = value;
    }

    /// <summary>
    /// Represents the name of the property that contains the name of the entities in the collection.
    /// </summary>
    public new string? EntityNamePropertyName
    {
        get => base.EntityNamePropertyName;
        set => base.EntityNamePropertyName = value;
    }

    public new string? EntityKeyPropertyName
    {
        get => base.EntityKeyPropertyName;
        set => base.EntityKeyPropertyName = value;
    }
}
