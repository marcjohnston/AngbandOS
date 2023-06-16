namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration55 : ChestTrapConfiguration
{
    private ChestTrapConfiguration55(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new ParalyzeChestTrap() };
}