using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class WarriorArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Str))
            {
                item.RandartFlags1.Set(ItemFlag1.Str);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            else if (item.RandartFlags1.IsClear(ItemFlag1.Con))
            {
                item.RandartFlags1.Set(ItemFlag1.Con);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            else if (item.RandartFlags1.IsClear(ItemFlag1.Dex))
            {
                item.RandartFlags1.Set(ItemFlag1.Dex);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyRandomResistances(Item item)
        {
            if (Program.Rng.DieRoll(3) != 1 && item.RandartFlags2.IsClear(ItemFlag2.ResFear))
            {
                item.RandartFlags2.Set(ItemFlag2.ResFear);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(3) == 1 && item.RandartFlags3.IsClear(ItemFlag3.NoMagic))
            {
                item.RandartFlags3.Set(ItemFlag3.NoMagic);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override int ActivationPowerChance => 80;
        public override IActivationPower GetActivationPowerType(Item item)
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
