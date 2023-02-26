namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration43 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration43(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap(), new SummonChestTrap() };
    }
}