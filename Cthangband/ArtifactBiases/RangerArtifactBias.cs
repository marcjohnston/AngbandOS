using Cthangband.ActivationPowers;
using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class RangerArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Con))
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
            else if (item.RandartFlags1.IsClear(ItemFlag1.Str))
            {
                item.RandartFlags1.Set(ItemFlag1.Str);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }

            return false;
        }
        public override bool ApplyMiscPowers(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.SustCon))
            {
                item.RandartFlags2.Set(ItemFlag2.SustCon);
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
                if (item.RandartFlags1.IsClear(ItemFlag1.SlayAnimal))
                {
                    item.RandartFlags1.Set(ItemFlag1.SlayAnimal);
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
