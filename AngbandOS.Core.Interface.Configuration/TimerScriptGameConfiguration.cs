namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class TimerScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns whether or not items are considered used.  Returns true, by default for timers.
    /// </summary>
    public virtual bool Used { get; set; } = true;

    /// <summary>
    /// Returns an expression that determine how much timer to add (positive values), subtract (negative values) to the timer; or null, to reset the timer to zero.
    /// </summary>
    public virtual string? ValueExpression { get; set; }

    /// <summary>
    /// Returns the binding key for the timer that the script will modify.
    /// </summary>
    public virtual string TimerBindingKey { get; set; }
    public virtual string? CustomLearnedDetails { get; set; } = null;
    public virtual bool Quiet { get; set; } = false;
    public virtual string? PreMessage { get; set; } = null;
    public virtual string? EnabledBoolPosFunctionBindingKey { get; set; } = null;
}
