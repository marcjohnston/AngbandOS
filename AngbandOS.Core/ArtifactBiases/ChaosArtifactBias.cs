using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class ChaosArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (!item.RandartItemCharacteristics.ResChaos)
            {
                item.RandartItemCharacteristics.ResChaos = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandartItemCharacteristics.ResConf)
            {
                item.RandartItemCharacteristics.ResConf = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandartItemCharacteristics.ResDisen)
            {
                item.RandartItemCharacteristics.ResDisen = false;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.Teleport)
            {
                item.RandartItemCharacteristics.Teleport = true;
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
                if (!item.RandartItemCharacteristics.Chaotic)
                {
                    item.RandartItemCharacteristics.Chaotic = true;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override int ActivationPowerChance => 50;

        public override ActivationPower GetActivationPowerType(Item item)
        {
            if (Program.Rng.DieRoll(6) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(SummonDemonActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(CallChaosActivationPower));
            }
        }
    }
}
