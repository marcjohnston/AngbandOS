namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration12 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration12(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap() };
    }
}