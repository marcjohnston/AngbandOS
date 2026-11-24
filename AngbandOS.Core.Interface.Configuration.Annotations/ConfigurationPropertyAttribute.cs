namespace AngbandOS.Core.Interface.Configuration.Annotations;

/// <summary>
/// Provides metadata describing a configuration property.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class ConfigurationPropertyAttribute : Attribute
{
    public ConfigurationPropertyAttribute(string dataType)
    {
        DataType = dataType;
    }

    /// <summary>
    /// Complete C# type of the property, including nullable annotations,
    /// arrays, and tuple definitions.
    ///
    /// Examples:
    ///     "string"
    ///     "string?"
    ///     "string?[]?"
    ///     "(string MethodName, string? EffectName, int Dice, int Sides)[]?"
    /// </summary>
    public string DataType { get; }

    /// <summary>
    /// Human-readable title rendered by the UI.
    /// </summary>
    public string? Title { get; set; } = null;

    /// <summary>
    /// Human-readable summary describing the purpose of the property.
    /// </summary>
    public string? Description { get; set; } = null;
    
    /// <summary>
    /// Label to display if the property is nullable.  Returns null (non-nullable), by default.  
    /// When null, nullable boolean properties will scaffold to the default value of "Default".
    /// </summary>
    public string? LabelIfNullable { get; set; } = null;

    /// <summary>
    /// Returns the default values for the property.  Non-string default values are converted to string format.  Returns null, if the property doesn't have a default value.  Properties
    /// that do not have a default value require the user to specify a value.  In no cases, is null considered a default value.
    /// </summary>
    /// <remarks>
    /// This property applies to the following types:
    /// boolean     DefaultValue = new string?[] { "true" };
    /// character   DefaultValue = new string?[] { "c" };
    /// enum        DefaultValue = new string?[] { "0" };
    /// foreign-key DefaultValue = new string?[] { "HumanRace" };
    /// integer     DefaultValue = new string?[] { "10" };
    /// string      DefaultValue = new string?[] { "Title" };
    /// array       DefaultValue = new string?[] { "10", "20", "30" };
    /// 2d-array    DefaultValue = new string?[] { "10", "20", "30" }; Flattened
    /// </remarks>
    public string?[]? DefaultValue { get; set; } = null;
}
