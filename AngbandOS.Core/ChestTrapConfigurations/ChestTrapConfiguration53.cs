namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration53 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new ParalyzeChestTrap(), new LoseStrChestTrap(), new LoseConChestTrap() };
    }
}