namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration32 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration32(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new SummonChestTrap() };
    }
}