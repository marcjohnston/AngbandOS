namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class ColdArtifactBias : ArtifactBias
    {
        private ColdArtifactBias(SaveGame saveGame) : base(saveGame) { }
        public override bool ApplyRandomResistances(Item item)
        {
            if (!item.RandartItemCharacteristics.ResCold)
            {
                item.RandartItemCharacteristics.ResCold = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandartItemCharacteristics.ImCold)
            {
                item.RandartItemCharacteristics.ImCold = true;
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
                if (!item.RandartItemCharacteristics.BrandCold)
                {
                    item.RandartItemCharacteristics.BrandCold = true;
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
                return SaveGame.SingletonRepository.Activations.Get<BoCold1Activation>();
            }
            else if (Program.Rng.DieRoll(3) != 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<BaCold1Activation>();
            }
            else if (Program.Rng.DieRoll(3) != 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<BaCold2Activation>();
            }
            else
            {
                return SaveGame.SingletonRepository.Activations.Get<BaCold3Activation>();
            }
        }
    }
}
