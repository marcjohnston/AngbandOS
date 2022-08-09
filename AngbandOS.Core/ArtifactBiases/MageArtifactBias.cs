using Cthangband.ActivationPowers;
using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class MageArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Int))
            {
                item.RandartFlags1.Set(ItemFlag1.Int);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override int ActivationPowerChance => 66;

        public override IActivationPower GetActivationPowerType(Item item)
        {
            if (Program.Rng.DieRoll(20) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(SummonElementalActivationPower));
            }
            else if (Program.Rng.DieRoll(10) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(SummonPhantomActivationPower));
            }
            else if (Program.Rng.DieRoll(5) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(RuneExploActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(EspActivationPower));
            }
        }
    }
}
