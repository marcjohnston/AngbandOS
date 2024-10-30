namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents a class that contains metadata description for class.  The properties of this class use public modifiers on the properties to enable standard Json serialization and a protected 
/// set modifier to prevent the property values from being set by anything but the derived classes.  This arrangement allows the Games controller to return an array of PropertyMetadata without
/// needing polymorphic serialiation.
/// </summary>
public class PropertyMetadata
{
    public PropertyMetadata(string type, string propertyName)
    {
        Type = type;
        PropertyName = propertyName;
    }

    /// <summary>
    /// Returns the name of the property in the configuration that the metadata references.
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// Returns the name of the property in the configuration that the metadata references.
    /// </summary>
    public string PropertyName { get; set; }

    /// <summary>
    /// Returns a title (or short description) of the property that can be presented to the user or null; in which the <see cref="PropertyName"/> should be used.
    /// </summary>
    public string? Title { get; set; } = null;

    /// <summary>
    /// Returns the category of the property, when presenting the property to the user or empty; if the property has no category and could be considered miscellaneous.
    /// </summary>
    public string CategoryTitle { get; set; } = "";

    /// <summary>
    /// Returns true, if the property value must be provided by the user.  Returns false, by default.
    /// </summary>
    public bool IsNullable { get; set; } = false;

    /// <summary>
    /// Returns a description of the property that can be presented to the user that provides the maximum amount of details on how the property is to be used.  Returns a blank description, by default.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Returns the default values for the property.  Non-string default values are converted to string format.  Returns null, if the property doesn't have a default value.  Properties
    /// that do not have a default value require the user to specify a value.  In no cases, is null considered a default value.
    /// </summary>
    public string[]? DefaultValue { get; protected set; } = null;

    /// <summary>
    /// Returns the name of the property that represents the primary key for a collection.  Returns null, if the property is not a collection.
    /// </summary>
    public string? KeyPropertyName { get; protected set; } = null;

    /// <summary>
    /// Returns the singular entity name for each of the objects in a collection.  Returns null, if the property is not a collection.
    /// </summary>
    public string? EntityTitle { get; protected set; } = null;

    /// <summary>
    /// Returns the additional associated property metadata descriptions relevant to the property.  Applies only to collections and tuples.  Collections use this property to describe their 
    /// children and tuples use this property to describe their data types.  Returns null, for non-collection and non-tuple properties.
    /// </summary>
    public PropertyMetadata[]? PropertyMetadatas { get; protected set; } = null;

    /// <summary>
    /// Returns the name of the collection for foreign-key properties.  Returns null, for non-foreign-key properties.
    /// </summary>
    public string? ForeignCollectionName { get; protected set; } = null;
}
