namespace AngbandOS.Core.Interface.Configuration.Annotations;

/// <summary>
/// Provides metadata describing an individual member of a tuple
/// configuration property.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
public sealed class ConfigurationTupleItemAttribute : Attribute
{
    public ConfigurationTupleItemAttribute(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A tuple item name must be specified.", nameof(name));
        }

        Name = name;
    }

    /// <summary>
    /// Name of the tuple item.  This name is used to match the tuple item with the corresponding property in the tuple data type.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Human-readable title rendered by the UI or null, to render the name.  Returns null, by default.
    /// </summary>
    public string? Title { get; set; } = null;

    /// <summary>
    /// Human-readable summary description describing the tuple item.  Returns null, by default.
    /// </summary>
    public string? Description { get; set; } = null;

    /// <summary>
    /// Name of the foreign collection referenced by this tuple item, if the tuple item references a foreign collection; null, otherwise.  Returns null, by default.
    /// </summary>
    public string? ForeignCollectionName { get; set; } = null;

    /// <summary>
    /// Returns true, if the tuple item is a foreign-key and the foreign object should be rendered inline in the UI, rather than as a link to the foreign object.
    /// Defaults to true for tuples.
    /// </summary>
    public bool Inline { get; set; } = true;

    /// <summary>
    /// Label to display if the property is nullable.  Returns null (non-nullable), by default.  
    /// When null, nullable boolean properties will scaffold to the default value of "Default".
    /// </summary>
    public string? LabelIfNullable { get; set; } = null;
}
