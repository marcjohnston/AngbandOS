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
    /// Name of the tuple item.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Human-readable title rendered by the UI.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Human-readable summary describing the tuple item.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Name of the foreign collection referenced by this tuple item.
    /// </summary>
    public string? ForeignCollectionName { get; set; }

    public bool Inline { get; set; }
}
