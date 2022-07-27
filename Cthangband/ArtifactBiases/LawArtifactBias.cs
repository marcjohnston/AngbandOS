using Cthangband.ActivationPowers;
using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class LawArtifactBias : ArtifactBias
    {
        public override bool ApplySlaying(Item item)
        {
            if (item.Category != ItemCategory.Bow)
            {
                if (item.RandartFlags1.IsClear(ItemFlag1.SlayEvil))
                {
                    item.RandartFlags1.Set(ItemFlag1.SlayEvil);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
                if (item.RandartFlags1.IsClear(ItemFlag1.SlayUndead))
                {
                    item.RandartFlags1.Set(ItemFlag1.SlayUndead);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
                if (item.RandartFlags1.IsClear(ItemFlag1.SlayDemon))
                {
                    item.RandartFlags1.Set(ItemFlag1.SlayDemon);
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
