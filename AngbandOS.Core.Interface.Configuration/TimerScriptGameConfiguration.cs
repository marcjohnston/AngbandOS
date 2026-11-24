using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TimerScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("bool",
        Title = "Used",
        Description = "Determines whether items are considered used by the timer.")]
    /// <summary>
    /// Returns whether or not items are considered used.  Returns true, by default for timers.
    /// </summary>
    public virtual bool Used { get; set; } = true;

    [ConfigurationProperty("string?",
        Title = "Value Expression",
        Description = "Specifies the expression used to modify the timer. Positive values add time, negative values subtract time, and null resets the timer to zero.")]
    /// <summary>
    /// Returns an expression that determine how much timer to add (positive values), subtract (negative values) to the timer; or null, to reset the timer to zero.
    /// </summary>
    public virtual string? ValueExpression { get; set; }

    [ConfigurationProperty("string",
        Title = "Timer Binding Key",
        Description = "Specifies the binding key of the timer modified by the script.")]
    /// <summary>
    /// Returns the binding key for the timer that the script will modify.
    /// </summary>
    public virtual string TimerBindingKey { get; set; }

    [ConfigurationProperty("string?",
        Title = "Custom Learned Details",
        Description = "Specifies custom details revealed when the timer script is learned.")]
    public virtual string? CustomLearnedDetails { get; set; } = null;

    [ConfigurationProperty("bool",
        Title = "Quiet",
        Description = "Determines whether the timer script executes without displaying messages.")]
    public virtual bool Quiet { get; set; } = false;

    [ConfigurationProperty("string?",
        Title = "Pre-Message",
        Description = "Specifies the message displayed before the timer script executes.")]
    public virtual string? PreMessage { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Enabled Boolean Positive Function Binding Key",
        Description = "Specifies the optional binding key for the function that determines whether the timer script is enabled.")]
    public virtual string? EnabledBoolPosFunctionBindingKey { get; set; } = null;
}
