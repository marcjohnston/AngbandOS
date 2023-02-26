namespace AngbandOS.Core.ChestTrapConfigurations
{
    [Serializable]
    internal class ChestTrapConfiguration29 : ChestTrapConfiguration
    {
        private ChestTrapConfiguration29(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap(), new LoseConChestTrap() };
    }
}