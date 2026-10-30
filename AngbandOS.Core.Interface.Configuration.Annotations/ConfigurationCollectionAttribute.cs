using System.Collections;

namespace AngbandOS.Core.Interface.Configuration.Annotations;

/// <summary>
/// Identifies a configuration class as an entity that can be
/// referenced as a foreign collection.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class ConfigurationCollectionAttribute : Attribute
{
    public ConfigurationCollectionAttribute(string collectionName)
    {
        if (string.IsNullOrWhiteSpace(collectionName))
        {
            throw new ArgumentException(
                "A foreign collection name must be specified.",
                nameof(collectionName));
        }

        CollectionName = collectionName;
    }

    /// <summary>
    /// Singular noun used when referring to an individual entity in the collection.  This noun completes a statement of "This is a(n) 'what'."
    /// </summary>
    public string? EntityNoun { get; set; }

    public string CollectionName { get; }
}
