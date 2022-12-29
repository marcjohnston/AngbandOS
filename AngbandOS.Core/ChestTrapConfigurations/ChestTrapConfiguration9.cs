namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration9 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap() };
    }
}