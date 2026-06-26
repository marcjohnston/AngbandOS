
namespace AngbandOS.Core.Interface.Configuration;

public class GameCommandGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual char KeyChar { get; set; }
    public virtual int? Repeat { get; set; } = 0;
    public virtual bool IsEnabled { get; set; } = true;
    /// <foreign-collection-name>Scripts</foreign-collection-name>
    public virtual string? ExecuteScriptName { get; set; }
}
