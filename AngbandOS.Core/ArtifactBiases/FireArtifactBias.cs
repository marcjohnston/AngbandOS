using Cthangband.ActivationPowers;
using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class FireArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.ResFire))
            {
                item.RandartFlags2.Set(ItemFlag2.ResFire);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (item.Category >= ItemCategory.Cloak &&
                item.Category <= ItemCategory.HardArmor &&
                item.RandartFlags3.IsClear(ItemFlag3.ShFire))
            {
                item.RandartFlags3.Set(ItemFlag3.ShFire);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(ImmunityLuckOneInChance) == 1 && item.RandartFlags2.IsClear(ItemFlag2.ImFire))
            {
                item.RandartFlags2.Set(ItemFlag2.ImFire);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (item.RandartFlags3.IsClear(ItemFlag3.Lightsource))
            {
                item.RandartFlags3.Set(ItemFlag3.Lightsource);
            }
            return false;
        }

        public override bool ApplySlaying(Item item)
        {
            if (item.Category != ItemCategory.Bow)
            {
                if (item.RandartFlags1.IsClear(ItemFlag1.BrandFire))
                {
                    item.RandartFlags1.Set(ItemFlag1.BrandFire);
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
                return ActivationPowerManager.FindByType(typeof(BoFire1ActivationPower));
            }
            else if (Program.Rng.DieRoll(5) != 1)
            {
                return ActivationPowerManager.FindByType(typeof(BaFire1ActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(BaFire2ActivationPower));
            }
        }
    }
}
