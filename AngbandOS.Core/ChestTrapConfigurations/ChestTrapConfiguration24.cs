namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration24 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseConChestTrap() };
    }
}