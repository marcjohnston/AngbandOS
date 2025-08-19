
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ChestTrapGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual string ActivationGridTileScriptBindingKey { get; set; }
    public virtual string Description { get; set; }
}
