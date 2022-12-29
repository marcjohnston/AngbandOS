namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration31 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ParalyzeChestTrap() };
    }
}