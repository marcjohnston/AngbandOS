using Cthangband.ActivationPowers;
using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class PriestlyArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Wis))
            {
                item.RandartFlags1.Set(ItemFlag1.Wis);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplySlaying(Item item)
        {
            if ((item.Category == ItemCategory.Sword || item.Category == ItemCategory.Polearm) && item.RandartFlags3.IsClear(ItemFlag3.Blessed))
            {
                item.RandartFlags3.Set(ItemFlag3.Blessed);
            }
            return false;
        }

        public override IActivationPower GetActivationPowerType(Item item)
        {
            if (Program.Rng.DieRoll(13) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(CharmUndeadActivationPower));
            }
            else if (Program.Rng.DieRoll(12) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(BanishEvilActivationPower));
            }
            else if (Program.Rng.DieRoll(11) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(DispEvilActivationPower));
            }
            else if (Program.Rng.DieRoll(10) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(ProtEvilActivationPower));
            }
            else if (Program.Rng.DieRoll(9) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(Cure1000ActivationPower));
            }
            else if (Program.Rng.DieRoll(8) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(Cure700ActivationPower));
            }
            else if (Program.Rng.DieRoll(7) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(RestAllActivationPower));
            }
            else if (Program.Rng.DieRoll(6) == 1)
            {
                return ActivationPowerManager.FindByType(typeof(RestLifeActivationPower));
            }
            else
            {
                return ActivationPowerManager.FindByType(typeof(CureMwActivationPower));
            }
        }
    }
}
