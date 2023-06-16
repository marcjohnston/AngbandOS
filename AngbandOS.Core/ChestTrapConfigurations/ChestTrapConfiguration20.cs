namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration20 : ChestTrapConfiguration
{
    private ChestTrapConfiguration20(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap(), new LoseConChestTrap() };
}