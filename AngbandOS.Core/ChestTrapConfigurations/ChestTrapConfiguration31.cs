namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration31 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration31(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ParalyzeChestTrap() };
    }
}