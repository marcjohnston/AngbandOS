namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class TimerScriptGameConfiguration
{
    public virtual bool Used { get; set; }
    public virtual string Key { get; set; }
    public virtual string? ValueExpression { get; set; }
    public virtual string TimerBindingKey { get; set; }
    public virtual string? LearnedDetails { get; set; } = null;
}
