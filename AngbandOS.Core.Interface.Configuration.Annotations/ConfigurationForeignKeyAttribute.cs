namespace AngbandOS.Core.Interface.Configuration.Annotations;

/// <summary>
/// Identifies a property as being a foreign key that referenced an entity collection.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class ConfigurationForeignKeyAttribute : Attribute
{
    public ConfigurationForeignKeyAttribute(string collectionName)
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
    /// Name of the referenced foreign collection.
    /// </summary>
    public string CollectionName { get; }

    /// <summary>
    /// Indicates that the foreign object's properties should be
    /// rendered inline rather than requiring selection of an
    /// existing foreign object.
    /// </summary>
    public bool Inline { get; set; }
}