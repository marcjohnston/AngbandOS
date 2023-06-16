namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration24 : ChestTrapConfiguration
{
    private ChestTrapConfiguration24(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseConChestTrap() };
}