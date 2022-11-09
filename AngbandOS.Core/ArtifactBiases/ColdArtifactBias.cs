using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class ColdArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (!item.RandartItemCharacteristics.ResCold)
            {
                item.RandartItemCharacteristics.ResCold = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandartItemCharacteristics.ImCold)
            {
                item.RandartItemCharacteristics.ImCold = true;
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
                if (!item.RandartItemCharacteristics.BrandCold)
                {
                    item.RandartItemCharacteristics.BrandCold = true;
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
