using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class LawArtifactBias : ArtifactBias
    {
        public override bool ApplySlaying(Item item)
        {
            if (item.Category != ItemCategory.Bow)
            {
                if (!item.RandartItemCharacteristics.SlayEvil)
                {
                    item.RandartItemCharacteristics.SlayEvil = true;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
                if (!item.RandartItemCharacteristics.SlayUndead)
                {
                    item.RandartItemCharacteristics.SlayUndead = true;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
                if (!item.RandartItemCharacteristics.SlayDemon)
                {
                    item.RandartItemCharacteristics.SlayDemon = true;
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
            if (Program.Rng.DieRoll(8) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(BanishEvilActivationPower));
            }
            else if (Program.Rng.DieRoll(4) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(DispEvilActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(ProtEvilActivationPower));
            }
        }
    }
}
