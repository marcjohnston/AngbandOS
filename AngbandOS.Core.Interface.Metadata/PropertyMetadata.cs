namespace AngbandOS.Core.Interface.Metadata;

/// <summary>
/// Represents a class that contains metadata description for class.  The properties of this class use public modifiers on the properties to enable standard Json serialization and a protected 
/// set modifier to prevent the property values from being set by anything but the derived classes.  This arrangement allows the Games controller to return an array of PropertyMetadata without
/// needing polymorphic serialization.
/// </summary>
/// <remarks>
/// This class is an abstract class and the set accessors are all protected with the expectation that each derived class uses the "new" modifier on the
/// properties to expose the set accessors as public.  This arrangement allows the Games controller to return an array of PropertyMetadata without needing polymorphic serialization.
/// </remarks>
public abstract class PropertyMetadata
{
    public PropertyMetadata(string type, string propertyName)
    {
        Type = type;
        PropertyName = propertyName;
    }

    /// <summary>
    /// Returns the type of the property.  This type is used by the game-designer to render an applicable component.
    /// </summary>
    /// <remarks>
    /// The recognized values are:
    ///    Name             Matches                                         Notes
    /// 1. boolean          bool, bool?
    /// 2. character        char, char?
    /// 3. collection       *GameConfiguration[], *GameConfiguration[]?     
    /// 5. enum             *Enum, *Enum?                                   The enum type must be decorated with the EnumMetadataAttribute
    /// 6. foreign-key      a string that points to a collection entity by key (which is always a string)
    /// 7. foreign-keys     TBD ... this should be represented by an isArray = true
    /// 8. integer
    /// 9. string
    /// 10. strings         TBD ... this should be represented by an isArray = true 
    /// 11. tuple           automatically assumes array
    /// 12. array           AssociatedProperties contains 1 item representing the underlying type.
    /// 13. 2d-array        AssociatedProperties contains 1 item representing the underlying type.
    /// </remarks>
    public string Type { get; }

    /// <summary>
    /// Returns the name of the property.
    /// </summary>
    /// <remarks>
    /// This property applies to all types.
    /// </remarks>
    public string PropertyName { get; set; }

    /// <summary>
    /// Returns the title (or short description) of the property that can be presented to the user or null; in which the <see cref="PropertyName"/> should be rendered.
    /// </summary>
    /// <remarks>
    /// This property applies to all types.
    /// </remarks>
    public string? Title { get; set; } = null;

    /// <summary>
    /// Returns the category of the property, when presenting the property to the user or empty; if the property has no category and could be considered miscellaneous.  Returns a blank title 
    /// </summary>
    /// <remarks>
    /// This property applies to all types.
    /// </remarks>
    public string CategoryTitle { get; set; } = "";

    /// <summary>
    /// Returns the label to display when a property is nullable and the value is null, or null when the property is not nullable.
    /// </summary>
    /// <remarks>
    /// This property applies to all types.
    /// </remarks>
    public string? LabelIfNullable { get; set; } = null;

    /// <summary>
    /// Returns a description (or long description) of the property that can be presented to the user that provides the maximum amount of details on how the property is to be used.  Returns a blank description, by default.
    /// </summary>
    /// <remarks>
    /// This property applies to all types.
    /// </remarks>
    public string Description { get; set; } = "";

    /// <summary>
    /// Returns the default values for the property.  Non-string default values are converted to string format.  Returns null, if the property doesn't have a default value.  Properties
    /// that do not have a default value require the user to specify a value.  In no cases, is null considered a default value.
    /// </summary>
    /// <remarks>
    /// This property applies to the following types:
    /// boolean
    /// character
    /// integer
    /// string
    /// </remarks>
    public string[]? DefaultValue { get; protected set; } = null;

    /// <summary>
    /// Returns the name of the property that represents the primary key for a collection.  Returns null, if the property is not a collection.
    /// </summary>
    public string? EntityKeyPropertyName { get; protected set; } = null;

    /// <summary>
    /// Returns the name of the property that represents the primary key for a collection.  Returns null, if the property is not a collection.
    /// </summary>
    public string? EntityNamePropertyName { get; protected set; } = null;

    /// <summary>
    /// Returns the singular entity name for each of the objects in a collection.  Returns null, if the property is not a collection.
    /// </summary>
    public string? EntityNoun { get; protected set; } = null;

    /// <summary>
    /// Returns the title to render for the entity name.
    /// </summary>
    public string? EntityNounTitle { get; protected set; } = null;

    /// <summary>
    /// Returns the additional associated property metadata descriptions relevant to the property.  Returns null, for non-applicable and data types.
    /// </summary>
    /// <remarks>
    /// This property applies to the following types:
    /// collection - describes the pronerties associated to the collection
    /// tuple - describe the data type items of the tuple
    /// array - describe the inner data type
    /// </remarks>
    public PropertyMetadata[]? AssociatedProperties { get; protected set; } = null;

    /// <summary>
    /// Returns the name of the collection for foreign-key properties.  Returns null, for non-applicable data types.
    /// </summary>
    /// <remarks>
    /// This property applies to the following types:
    /// foreign-key
    /// </remarks>
    public string? ForeignCollectionName { get; protected set; } = null;

    /// <summary>
    /// Returns true, if the foreign-key property should be rendered inline rather than requiring selection of an existing foreign object.  Returns null, for non-foreign-key properties.
    /// </summary>
    /// <remarks>
    /// This property applies to the following types:
    /// foreign-key
    /// </remarks>
    public bool? Inline { get; protected set; } = null;
}
