namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration4 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseConChestTrap() };
    }
}