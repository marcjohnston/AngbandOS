namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ChestTrapCombinationGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual string[] ChestTrapBindingKeys { get; set; }
}
