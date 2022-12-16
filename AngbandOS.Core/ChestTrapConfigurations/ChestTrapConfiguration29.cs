using AngbandOS.Core.ChestTraps;

namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration29 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new LoseStrChestTrap(), new LoseConChestTrap() };
    }
}