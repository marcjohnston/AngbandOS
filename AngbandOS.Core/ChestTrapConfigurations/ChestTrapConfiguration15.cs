namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration15 : ChestTrapConfiguration
{
    private ChestTrapConfiguration15(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap(), new LoseConChestTrap() };
}