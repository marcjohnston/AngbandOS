using AngbandOS.Core.ChestTraps;

namespace AngbandOS.Core.ChestTrapConfigurations
{
    internal class ChestTrapConfiguration38 : ChestTrapConfiguration
    {
        public override BaseChestTrap[] Traps => new BaseChestTrap[] { new ExplodeChestTrap() };
    }
}