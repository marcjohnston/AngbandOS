namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration25 : ChestTrapConfiguration
{
    private ChestTrapConfiguration25(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap() };
}