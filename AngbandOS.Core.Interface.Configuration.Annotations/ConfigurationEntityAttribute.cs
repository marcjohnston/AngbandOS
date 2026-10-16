namespace AngbandOS.Core.Interface.Configuration.Annotations;

/// <summary>
/// Identifies a configuration class as an entity that can be
/// referenced as a foreign collection.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class ConfigurationEntityAttribute : Attribute
{
    /// <summary>
    /// Human-readable title for the collection.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Singular noun used when referring to an individual entity
    /// in the collection.
    /// </summary>
    public string? EntityNoun { get; set; }
}
