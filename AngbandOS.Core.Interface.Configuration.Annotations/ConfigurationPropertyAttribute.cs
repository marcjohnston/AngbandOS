namespace AngbandOS.Core.Interface.Configuration.Annotations;

/// <summary>
/// Provides metadata describing a configuration property.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class ConfigurationPropertyAttribute : Attribute
{
    /// <summary>
    /// Human-readable title rendered by the UI.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Human-readable summary describing the purpose of the property.
    /// </summary>
    public string? Summary { get; set; }

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
    public string? DataType { get; set; }
    
    /// <summary>
    /// Label to display if the property is nullable.  Returns null, by default.  
    /// When null, nullable boolean properties will scaffold to the default value of "Default".
    /// </summary>
    public string? LabelIfNullable { get; set; } = null;
}
