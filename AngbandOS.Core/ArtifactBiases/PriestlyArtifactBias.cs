namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class PriestlyArtifactBias : ArtifactBias
    {
        private PriestlyArtifactBias(SaveGame saveGame) : base(saveGame) { }
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Wis)
            {
                item.RandartItemCharacteristics.Wis = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplySlaying(Item item)
        {
            if ((item.Category == ItemTypeEnum.Sword || item.Category == ItemTypeEnum.Polearm) && !item.RandartItemCharacteristics.Blessed)
            {
                item.RandartItemCharacteristics.Blessed = true;
            }
            return false;
        }

        public override Activation GetActivationPowerType(Item item)
        {
            if (Program.Rng.DieRoll(13) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<CharmUndeadActivation>();
            }
            else if (Program.Rng.DieRoll(12) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<BanishEvilActivation>();
            }
            else if (Program.Rng.DieRoll(11) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<DispEvilActivation>();
            }
            else if (Program.Rng.DieRoll(10) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<ProtEvilActivation>();
            }
            else if (Program.Rng.DieRoll(9) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<Cure1000Activation>();
            }
            else if (Program.Rng.DieRoll(8) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<Cure700Activation>();
            }
            else if (Program.Rng.DieRoll(7) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<RestAllActivation>();
            }
            else if (Program.Rng.DieRoll(6) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<RestLifeActivation>();
            }
            else
            {
                return SaveGame.SingletonRepository.Activations.Get<CureMwActivation>();
            }
        }
    }
}
