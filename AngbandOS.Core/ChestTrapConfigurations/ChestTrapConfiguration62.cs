namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration62 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap(), new SummonChestTrap() };
    }
}