namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration28 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new LoseConChestTrap() };
    }
}