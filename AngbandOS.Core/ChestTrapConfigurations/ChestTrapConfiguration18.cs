namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration18 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration18(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap() };
    }
}