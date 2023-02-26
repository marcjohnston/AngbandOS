namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration54 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration54(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new ParalyzeChestTrap() };
    }
}