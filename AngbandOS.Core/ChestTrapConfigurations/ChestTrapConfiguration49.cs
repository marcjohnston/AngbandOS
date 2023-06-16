namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration49 : ChestTrapConfiguration
{
    private ChestTrapConfiguration49(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new ParalyzeChestTrap(), new LoseStrChestTrap() };
}