namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration56 : ChestTrapConfiguration
{
    private ChestTrapConfiguration56(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap(), new SummonChestTrap() };
}