namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration44 : ChestTrapConfiguration
{
    private ChestTrapConfiguration44(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap(), new SummonChestTrap() };
}