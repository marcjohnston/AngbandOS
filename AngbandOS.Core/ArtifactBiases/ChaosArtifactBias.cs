using Cthangband.ActivationPowers;
using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class ChaosArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.ResChaos))
            {
                item.RandartFlags2.Set(ItemFlag2.ResChaos);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (item.RandartFlags2.IsClear(ItemFlag2.ResConf))
            {
                item.RandartFlags2.Set(ItemFlag2.ResConf);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (item.RandartFlags2.IsClear(ItemFlag2.ResDisen))
            {
                item.RandartFlags2.Set(ItemFlag2.ResDisen);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (item.RandartFlags3.IsClear(ItemFlag3.Teleport))
            {
                item.RandartFlags3.Set(ItemFlag3.Teleport);
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
                if (item.RandartFlags1.IsClear(ItemFlag1.Chaotic))
                {
                    item.RandartFlags1.Set(ItemFlag1.Chaotic);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override int ActivationPowerChance => 50;

        public override IActivationPower GetActivationPowerType(Item item)
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
