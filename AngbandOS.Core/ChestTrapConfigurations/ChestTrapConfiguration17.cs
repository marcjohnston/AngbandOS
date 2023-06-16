namespace AngbandOS.Core.ChestTrapConfigurations;

[Serializable]
internal class ChestTrapConfiguration17 : ChestTrapConfiguration
{
    private ChestTrapConfiguration17(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override BaseChestTrap[] Traps => new BaseChestTrap[] { };
}