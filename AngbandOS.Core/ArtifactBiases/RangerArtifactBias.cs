using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class RangerArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Con)
            {
                item.RandartItemCharacteristics.Con = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            else if (!item.RandartItemCharacteristics.Dex)
            {
                item.RandartItemCharacteristics.Dex = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            else if (!item.RandartItemCharacteristics.Str)
            {
                item.RandartItemCharacteristics.Str = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }

            return false;
        }
        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.SustCon)
            {
                item.RandartItemCharacteristics.SustCon = true;
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
                if (!item.RandartItemCharacteristics.SlayAnimal)
                {
                    item.RandartItemCharacteristics.SlayAnimal = true;
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
            if (Program.Rng.DieRoll(20) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(CharmAnimalsActivationPower));
            }
            else if (Program.Rng.DieRoll(7) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(SummonAnimalActivationPower));
            }
            else if (Program.Rng.DieRoll(6) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(CharmAnimalActivationPower));
            }
            else if (Program.Rng.DieRoll(4) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(ResistAllActivationPower));
            }
            else if (Program.Rng.DieRoll(3) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(SatiateActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(CurePoisonActivationPower));
            }
        }
    }
}
