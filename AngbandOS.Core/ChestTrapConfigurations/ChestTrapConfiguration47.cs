namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration47 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap(), new LoseConChestTrap() };
    }
}