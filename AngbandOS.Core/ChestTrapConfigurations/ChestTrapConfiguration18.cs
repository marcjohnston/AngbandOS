namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration18 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap() };
    }
}