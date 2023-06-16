namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration28 : ChestTrapConfiguration
{
    private ChestTrapConfiguration28(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new LoseConChestTrap() };
}