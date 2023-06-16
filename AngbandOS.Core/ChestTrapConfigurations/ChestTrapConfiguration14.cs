namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration14 : ChestTrapConfiguration
{
    private ChestTrapConfiguration14(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap(), new LoseConChestTrap() };
}