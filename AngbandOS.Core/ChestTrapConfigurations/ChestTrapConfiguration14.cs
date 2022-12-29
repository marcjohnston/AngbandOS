namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration14 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap(), new LoseConChestTrap() };
    }
}