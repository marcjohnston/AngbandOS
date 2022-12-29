namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration52 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new LoseStrChestTrap(), new LoseConChestTrap() };
    }
}