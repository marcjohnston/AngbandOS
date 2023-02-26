namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration50 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration50(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new ParalyzeChestTrap(), new LoseConChestTrap() };
    }
}