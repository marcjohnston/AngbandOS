namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration55 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new ParalyzeChestTrap() };
    }
}