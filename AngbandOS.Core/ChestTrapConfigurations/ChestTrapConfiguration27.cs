namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration27 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration27(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new LoseStrChestTrap() };
    }
}