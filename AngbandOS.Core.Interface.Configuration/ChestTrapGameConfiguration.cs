
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ChestTrapGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Activation Grid Tile Script Binding Key",
        Description = "The binding key identifying the grid tile script activated by the chest trap.")]
    public virtual string ActivationGridTileScriptBindingKey { get; set; }

    [ConfigurationProperty("string",
        Title = "Description",
        Description = "The description of the chest trap.")]
    public virtual string Description { get; set; }
}