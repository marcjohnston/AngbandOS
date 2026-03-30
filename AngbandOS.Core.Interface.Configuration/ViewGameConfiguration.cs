
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ViewGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string[] WidgetNames { get; set; }
}
