namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration11 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration11(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseConChestTrap() };
    }
}