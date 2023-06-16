namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration45 : ChestTrapConfiguration
{
    private ChestTrapConfiguration45(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new ParalyzeChestTrap() };
}