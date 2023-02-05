namespace AngbandOS.Core.ArtifactBiases
{
    internal class RogueArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Stealth)
            {
                item.RandartItemCharacteristics.Stealth = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplySlaying(Item item)
        {
            if (item.Category != ItemTypeEnum.Bow)
            {
                if (!item.RandartItemCharacteristics.BrandPois)
                {
                    item.RandartItemCharacteristics.BrandPois = true;
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
