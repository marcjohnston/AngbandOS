
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class GameCommandGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual char KeyChar { get; set; }
    public virtual int? Repeat { get; set; } = 0;
    public virtual bool IsEnabled { get; set; } = true;
    /// <foreign-collection-name>Scripts</foreign-collection-name>
    public virtual string? ExecuteScriptName { get; set; }

    //public bool IsValid()
    //{
    //    if (Key == null || KeyChar == null || IsEnabled == null)
    //    {
    //        return false;
    //    }
    //    return true;
    //}
}