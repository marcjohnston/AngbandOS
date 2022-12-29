namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration32 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new SummonChestTrap() };
    }
}