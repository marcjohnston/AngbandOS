namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration5 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap() };
    }
}