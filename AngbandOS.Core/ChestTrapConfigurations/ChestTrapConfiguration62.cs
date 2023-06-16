namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration62 : ChestTrapConfiguration
{
    private ChestTrapConfiguration62(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap(), new SummonChestTrap() };
}