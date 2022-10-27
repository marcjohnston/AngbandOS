using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class RogueArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Stealth))
            {
                item.RandartFlags1.Set(ItemFlag1.Stealth);
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
                if (item.RandartFlags1.IsClear(ItemFlag1.BrandPois))
                {
                    item.RandartFlags1.Set(ItemFlag1.BrandPois);
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
            if (Program.Rng.DieRoll(50) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(SpeedActivationPower));
            }
            else if (Program.Rng.DieRoll(4) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(SleepActivationPower));
            }
            else if (Program.Rng.DieRoll(3) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(DetectAllActivationPower));
            }
            else if (Program.Rng.DieRoll(8) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(IdFullActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(IdPlainActivationPower));
            }
        }
    }
}
