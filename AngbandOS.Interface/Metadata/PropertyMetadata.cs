namespace AngbandOS.Core.Interface;

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
}
