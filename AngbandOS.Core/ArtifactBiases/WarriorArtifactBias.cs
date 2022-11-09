using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class WarriorArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Str)
            {
                item.RandartItemCharacteristics.Str = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            else if (!item.RandartItemCharacteristics.Con)
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
            return false;
        }

        public override bool ApplyRandomResistances(Item item)
        {
            if (Program.Rng.DieRoll(3) != 1 && !item.RandartItemCharacteristics.ResFear)
            {
                item.RandartItemCharacteristics.ResFear = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(3) == 1 && !item.RandartItemCharacteristics.NoMagic)
            {
                item.RandartItemCharacteristics.NoMagic = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override int ActivationPowerChance => 80;
        public override ActivationPower GetActivationPowerType(Item item)
        {
            if (Program.Rng.DieRoll(100) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(InvulnActivationPower));

            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(BerserkActivationPower));
            }
        }
    }
}
