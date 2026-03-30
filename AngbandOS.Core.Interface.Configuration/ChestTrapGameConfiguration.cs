
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ChestTrapGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string ActivationGridTileScriptBindingKey { get; set; }
    public virtual string Description { get; set; }
}
