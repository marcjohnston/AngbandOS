using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TimerScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Used",
        Summary = "Determines whether items are considered used by the timer.",
        DataType = "bool")]
    /// <summary>
    /// Returns whether or not items are considered used.  Returns true, by default for timers.
    /// </summary>
    public virtual bool Used { get; set; } = true;

    [ConfigurationMetadata(
        Title = "Value Expression",
        Summary = "Specifies the expression used to modify the timer. Positive values add time, negative values subtract time, and null resets the timer to zero.",
        DataType = "string?")]
    /// <summary>
    /// Returns an expression that determine how much timer to add (positive values), subtract (negative values) to the timer; or null, to reset the timer to zero.
    /// </summary>
    public virtual string? ValueExpression { get; set; }

    [ConfigurationMetadata(
        Title = "Timer Binding Key",
        Summary = "Specifies the binding key of the timer modified by the script.",
        DataType = "string")]
    /// <summary>
    /// Returns the binding key for the timer that the script will modify.
    /// </summary>
    public virtual string TimerBindingKey { get; set; }

    [ConfigurationMetadata(
        Title = "Custom Learned Details",
        Summary = "Specifies custom details revealed when the timer script is learned.",
        DataType = "string?")]
    public virtual string? CustomLearnedDetails { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Quiet",
        Summary = "Determines whether the timer script executes without displaying messages.",
        DataType = "bool")]
    public virtual bool Quiet { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Pre-Message",
        Summary = "Specifies the message displayed before the timer script executes.",
        DataType = "string?")]
    public virtual string? PreMessage { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Enabled Boolean Positive Function Binding Key",
        Summary = "Specifies the optional binding key for the function that determines whether the timer script is enabled.",
        DataType = "string?")]
    public virtual string? EnabledBoolPosFunctionBindingKey { get; set; } = null;
}
