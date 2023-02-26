namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration52 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration52(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new LoseStrChestTrap(), new LoseConChestTrap() };
    }
}