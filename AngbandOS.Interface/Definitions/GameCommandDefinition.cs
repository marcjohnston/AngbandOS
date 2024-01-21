namespace AngbandOS.Core.Interface.Definitions;

[Serializable]
public class GameCommandDefinition
{
    public string Key { get; set; }
    public char KeyChar { get; set; }
    public int? Repeat { get; set; } = 0;
    public bool IsEnabled { get; set; } = true;
    public string ExecuteScriptName { get; set; }
}