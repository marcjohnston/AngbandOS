namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration56 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap(), new SummonChestTrap() };
    }
}