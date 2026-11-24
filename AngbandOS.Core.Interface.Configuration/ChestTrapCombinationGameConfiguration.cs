using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ChestTrapCombinationGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string[]",
        Title = "Chest Trap Binding Keys",
        Description = "The binding keys identifying the chest traps included in this combination.")]
    public virtual string[] ChestTrapBindingKeys { get; set; }
}