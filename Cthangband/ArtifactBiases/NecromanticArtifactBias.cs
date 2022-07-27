using Cthangband.ActivationPowers;
using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class NecromanticArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.ResNether))
            {
                item.RandartFlags2.Set(ItemFlag2.ResNether);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (item.RandartFlags2.IsClear(ItemFlag2.ResPois))
            {
                item.RandartFlags2.Set(ItemFlag2.ResPois);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (item.RandartFlags2.IsClear(ItemFlag2.ResDark))
            {
                item.RandartFlags2.Set(ItemFlag2.ResDark);
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
                if (item.RandartFlags1.IsClear(ItemFlag1.Vampiric))
                {
                    item.RandartFlags1.Set(ItemFlag1.Vampiric);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
                if (item.RandartFlags1.IsClear(ItemFlag1.BrandPois) && Program.Rng.DieRoll(2) == 1)
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
            if (Program.Rng.DieRoll(66) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(WraithActivationPower));
            }
            else if (Program.Rng.DieRoll(13) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(DispGoodActivationPower));
            }
            else if (Program.Rng.DieRoll(9) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(MassGenoActivationPower));
            }
            else if (Program.Rng.DieRoll(8) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(CarnageActivationPower));
            }
            else if (Program.Rng.DieRoll(13) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(SummonUndeadActivationPower));
            }
            else if (Program.Rng.DieRoll(9) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(Vampire2ActivationPower));
            }
            else if (Program.Rng.DieRoll(6) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(CharmUndeadActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(Vampire1ActivationPower));
            }
        }
    }
}
