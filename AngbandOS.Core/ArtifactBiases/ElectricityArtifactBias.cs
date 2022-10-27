using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class ElectricityArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.ResElec))
            {
                item.RandartFlags2.Set(ItemFlag2.ResElec);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (item.Category >= ItemCategory.Cloak &&
                item.Category <= ItemCategory.HardArmor &&
                item.RandartFlags3.IsClear(ItemFlag3.ShElec))
            {
                item.RandartFlags3.Set(ItemFlag3.ShElec);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(ImmunityLuckOneInChance) == 1 && item.RandartFlags2.IsClear(ItemFlag2.ImElec))
            {
                item.RandartFlags2.Set(ItemFlag2.ImElec);
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
                if (item.RandartFlags1.IsClear(ItemFlag1.BrandElec))
                {
                    item.RandartFlags1.Set(ItemFlag1.BrandElec);
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
                return ActivationPowerManager.FindByType(typeof(BoElec1ActivationPower));
            }
            else if (Program.Rng.DieRoll(5) != 1)
            {
                return ActivationPowerManager.FindByType(typeof(BaElec2ActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(BaElec3ActivationPower));
            }
        }
    }
}
