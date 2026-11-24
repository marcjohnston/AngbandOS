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
    /// Human-readable title rendered by the UI.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Human-readable summary describing the purpose of the property.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Label to display if the property is nullable.  Returns null (non-nullable), by default.  
    /// When null, nullable boolean properties will scaffold to the default value of "Default".
    /// </summary>
    public string? LabelIfNullable { get; set; } = null;

    /// <summary>
    /// Singular noun used when referring to an individual entity in the collection or null, to simply use the collection name.  This noun completes a statement of "This is a(n) 'what'."
    /// Returns null, by default.
    /// </summary>
    public string? EntityNounTitle { get; set; } = null;

    /// <summary>
    /// Returns the name of the collection for the items.  Multiple properties may contribute to the same collection (e.g. CauseWoundsMonsterSpells, ProjectileMonsterSpells, ScriptMonsterSpells and SummonMonsterSpells
    /// all contribute to the MonsterSpells collection).
    /// </summary>
    public string CollectionName { get; }

    /// <summary>
    /// Returns the name of the property that represents the entity name or null, to use the collection key.  Returns null, by default.
    /// </summary>
    public string? EntityNamePropertyName { get; set; } = null;
}
