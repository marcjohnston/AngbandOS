using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class NecromanticArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (!item.RandartItemCharacteristics.ResNether)
            {
                item.RandartItemCharacteristics.ResNether = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandartItemCharacteristics.ResPois)
            {
                item.RandartItemCharacteristics.ResPois = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandartItemCharacteristics.ResDark)
            {
                item.RandartItemCharacteristics.ResDark = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplySlaying(Item item)
        {
            if (item.Category != ItemTypeEnum.Bow)
            {
                if (!item.RandartItemCharacteristics.Vampiric)
                {
                    item.RandartItemCharacteristics.Vampiric = true;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
                if (!item.RandartItemCharacteristics.BrandPois && Program.Rng.DieRoll(2) == 1)
                {
                    item.RandartItemCharacteristics.BrandPois = true;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override ActivationPower GetActivationPowerType(Item item)
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
