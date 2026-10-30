
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ChestTrapGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Activation Grid Tile Script Binding Key",
        Summary = "The binding key identifying the grid tile script activated by the chest trap.",
        DataType = "string")]
    public virtual string ActivationGridTileScriptBindingKey { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Description",
        Summary = "The description of the chest trap.",
        DataType = "string")]
    public virtual string Description { get; set; }
}