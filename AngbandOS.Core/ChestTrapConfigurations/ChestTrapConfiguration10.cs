namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration10 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap() };
    }
}