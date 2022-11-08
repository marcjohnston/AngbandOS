using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class MageArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Int)
            {
                item.RandartItemCharacteristics.Int = true;
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
