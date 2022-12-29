namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration8 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap() };
    }
}