namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration11 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseConChestTrap() };
    }
}