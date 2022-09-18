using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class PoisonArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.ResPois))
            {
                item.RandartFlags2.Set(ItemFlag2.ResPois);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplySlaying(Item item)
        {
            if (item.Category != ItemCategory.Bow)
            {
                if (item.RandartFlags1.IsClear(ItemFlag1.BrandPois))
                {
                    item.RandartFlags1.Set(ItemFlag1.BrandPois);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override IActivationPower GetActivationPowerType(Item item)
        {
            return ActivationPowerManager.FindByType(typeof(BaPois1ActivationPower));
        }
    }
}
