namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration42 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration42(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap() };
    }
}