namespace AngbandOS.Core.Interface.Configuration.Annotations;

/// <summary>
/// Represents a metadata attribute to places a configuration property into a named UI category.  These annotations can be applied optionally to any and all properties for
/// an entity.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class ConfigurationCategoryAttribute : Attribute
{
    public ConfigurationCategoryAttribute(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException(
                "A category title must be specified.",
                nameof(title));
        }

        Title = title;
    }

    /// <summary>
    /// Title displayed for the UI category.
    /// </summary>
    public string Title { get; }
}
