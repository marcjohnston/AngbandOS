namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents the common properties for both tuple and simple property metadata.  This class is abstract because the TuplePropertyMetadata and the 
/// SimplePropertyMetadata classes add a differing Type property to denote support for either a Tuple type or a non-tuple "simple" type.
/// </summary>
public abstract class PropertyMetadata
{
    public PropertyMetadata(string propertyName, string type)
    {
        if (String.IsNullOrEmpty(propertyName))
        {
            throw new Exception($"The {nameof(propertyName)} parameter cannot be null or empty.");
        }
        PropertyName = propertyName;
        Type = type;
    }

    /// <summary>
    /// Returns the name of the configuration property to assign the user value to.
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// Returns the name of the configuration property to assign the user value to.
    /// </summary>
    public string PropertyName { get; }

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
    /// Returns true, if the property supports more than one value.  Returns false, by default.
    /// </summary>
    public bool IsArray { get; set; } = false;

    /// <summary>
    /// Returns a description of the property that can be presented to the user that provides the maximum amount of details on how the property is to be used.  Returns a blank description, by default.
    /// </summary>
    public string? Description { get; set; } = "";

    /// <summary>
    /// Returns the title to be used for each entity.  This is typically the singular version of the <see cref="Title"/> property; or null, if the collection <see cref="Title"/> should be used.
    /// </summary>
    public string? CollectionEntityTitle { get; set; } = null;

    public string? CollectionKeyPropertyName { get; set; } = null;

    public int? DefaultIntegerValue { get; set; } = null;

    public bool? DefaultBooleanValue { get; set; } = null;

    public char? DefaultCharacterValue { get; set; } = null;

    public string? DefaultStringValue { get; set; } = null;

    public PropertyMetadata[]? CollectionPropertiesMetadata { get; set; } = null;

    public PropertyMetadata[]? TupleTypes { get; set; } = null;
}
