namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration19 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration19(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseConChestTrap(), new ParalyzeChestTrap() };
    }
}