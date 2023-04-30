namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class PoisonArtifactBias : ArtifactBias
    {
        private PoisonArtifactBias(SaveGame saveGame) : base(saveGame) { }
        public override bool ApplyRandomResistances(Item item)
        {
            if (!item.RandartItemCharacteristics.ResPois)
            {
                item.RandartItemCharacteristics.ResPois = true;
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

        public override Activation GetActivationPowerType(Item item)
        {
            return SaveGame.SingletonRepository.Activations.Get<BaPois1Activation>();
        }
    }
}
