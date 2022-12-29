namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration6 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseConChestTrap() };
    }
}