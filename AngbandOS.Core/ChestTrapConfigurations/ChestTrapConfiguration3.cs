namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration3 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap() };
    }
}