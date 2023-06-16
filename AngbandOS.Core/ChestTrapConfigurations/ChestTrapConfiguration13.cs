namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration13 : ChestTrapConfiguration
{
    private ChestTrapConfiguration13(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap(), new LoseConChestTrap() };
}