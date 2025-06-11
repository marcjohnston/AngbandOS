
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ViewGameConfiguration
{
    public virtual string[] WidgetNames { get; set; }

    public virtual string? Key { get; set; } = null;
}
