namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration20 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap(), new LoseConChestTrap() };
    }
}