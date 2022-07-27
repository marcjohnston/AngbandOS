using Cthangband.ActivationPowers;
using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class ColdArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.ResCold))
            {
                item.RandartFlags2.Set(ItemFlag2.ResCold);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(ImmunityLuck) == 1 && item.RandartFlags2.IsClear(ItemFlag2.ImCold))
            {
                item.RandartFlags2.Set(ItemFlag2.ImCold);
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
                if (item.RandartFlags1.IsClear(ItemFlag1.BrandCold))
                {
                    item.RandartFlags1.Set(ItemFlag1.BrandCold);
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
            if (Program.Rng.DieRoll(3) != 1)
            {
                return ActivationPowerManager.FindByType(typeof(BoCold1ActivationPower));
            }
            else if (Program.Rng.DieRoll(3) != 1)
            {
                return ActivationPowerManager.FindByType(typeof(BaCold1ActivationPower));
            }
            else if (Program.Rng.DieRoll(3) != 1)
            {
                return ActivationPowerManager.FindByType(typeof(BaCold2ActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(BaCold3ActivationPower));
            }
        }
    }
}
