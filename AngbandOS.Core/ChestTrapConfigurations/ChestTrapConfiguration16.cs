namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration16 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new SummonChestTrap() };
    }
}