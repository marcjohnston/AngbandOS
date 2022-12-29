namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration27 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new PoisonChestTrap(), new LoseStrChestTrap() };
    }
}