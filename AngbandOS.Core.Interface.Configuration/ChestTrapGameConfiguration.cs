
namespace AngbandOS.Core.Interface.Configuration;

public class ChestTrapGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string ActivationGridTileScriptBindingKey { get; set; }
    public virtual string Description { get; set; }
}
