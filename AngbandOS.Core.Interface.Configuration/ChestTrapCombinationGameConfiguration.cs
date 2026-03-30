namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ChestTrapCombinationGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string[] ChestTrapBindingKeys { get; set; }
}
