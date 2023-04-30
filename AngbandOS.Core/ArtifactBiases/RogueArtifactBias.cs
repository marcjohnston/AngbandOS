namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class RogueArtifactBias : ArtifactBias
    {
        private RogueArtifactBias(SaveGame saveGame) : base(saveGame) { }
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

        public override Activation GetActivationPowerType(Item item)
        {
            if (Program.Rng.DieRoll(50) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<SpeedActivation>();
            }
            else if (Program.Rng.DieRoll(4) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<SleepActivation>();
            }
            else if (Program.Rng.DieRoll(3) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<DetectAllActivation>();
            }
            else if (Program.Rng.DieRoll(8) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<IdFullActivation>();
            }
            else
            {
                return SaveGame.SingletonRepository.Activations.Get<IdPlainActivation>();
            }
        }
    }
}
