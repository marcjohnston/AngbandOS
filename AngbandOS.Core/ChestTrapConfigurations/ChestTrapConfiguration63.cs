namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration63 : ChestTrapConfiguration
{
    private ChestTrapConfiguration63(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap(), new SummonChestTrap() };
}
