namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration53 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration53(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new ParalyzeChestTrap(), new LoseStrChestTrap(), new LoseConChestTrap() };
    }
}