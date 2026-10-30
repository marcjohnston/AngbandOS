using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ChestTrapCombinationGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Chest Trap Binding Keys",
        Summary = "The binding keys identifying the chest traps included in this combination.",
        DataType = "string[]")]
    public virtual string[] ChestTrapBindingKeys { get; set; }
}