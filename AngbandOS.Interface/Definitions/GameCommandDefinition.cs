namespace AngbandOS.Core.Interface.Definitions;

[Serializable]
public class GameCommandDefinition : IPoco
{
    public virtual string Key { get; set; }
    public virtual char KeyChar { get; set; }
    public virtual int? Repeat { get; set; } = 0;
    public virtual bool IsEnabled { get; set; } = true;
    public virtual string ExecuteScriptName { get; set; }

    public bool IsValid()
    {
        if (Key == null || KeyChar == null || IsEnabled == null || ExecuteScriptName == null)
        {
            return false;
        }
        return true;
    }
}