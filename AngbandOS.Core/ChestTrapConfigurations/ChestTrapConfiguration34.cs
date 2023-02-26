namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration34 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration34(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap() };
    }
}