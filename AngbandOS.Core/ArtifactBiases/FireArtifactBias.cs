namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class FireArtifactBias : ArtifactBias
    {
        private FireArtifactBias(SaveGame saveGame) : base(saveGame) { }
        public override bool ApplyRandomResistances(Item item)
        {
            if (!item.RandartItemCharacteristics.ResFire)
            {
                item.RandartItemCharacteristics.ResFire = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (item.Category >= ItemTypeEnum.Cloak && item.Category <= ItemTypeEnum.HardArmor && !item.RandartItemCharacteristics.ShFire)
            {
                item.RandartItemCharacteristics.ShFire = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandartItemCharacteristics.ImFire)
            {
                item.RandartItemCharacteristics.ImFire = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.Lightsource)
            {
                item.RandartItemCharacteristics.Lightsource = true;
            }
            return false;
        }

        public override bool ApplySlaying(Item item)
        {
            if (item.Category != ItemTypeEnum.Bow)
            {
                if (!item.RandartItemCharacteristics.BrandFire)
                {
                    item.RandartItemCharacteristics.BrandFire = true;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override Activation GetActivationPowerType(Item item)
        {
            if (Program.Rng.DieRoll(3) != 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<BoFire1Activation>();
            }
            else if (Program.Rng.DieRoll(5) != 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<BaFire1Activation>();
            }
            else
            {
                return SaveGame.SingletonRepository.Activations.Get<BaFire2Activation>();
            }
        }
    }
}
