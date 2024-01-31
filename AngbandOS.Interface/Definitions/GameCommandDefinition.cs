namespace AngbandOS.Core.Interface.Definitions;

[Serializable]
public class GameCommandDefinition
{
    public virtual string Key { get; set; }
    public virtual char KeyChar { get; set; }
    public virtual int? Repeat { get; set; } = 0;
    public virtual bool IsEnabled { get; set; } = true;
    public virtual string ExecuteScriptName { get; set; }
}