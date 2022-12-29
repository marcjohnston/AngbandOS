namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration50 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new ParalyzeChestTrap(), new LoseConChestTrap() };
    }
}