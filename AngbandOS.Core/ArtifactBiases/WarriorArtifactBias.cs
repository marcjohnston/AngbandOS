namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class WarriorArtifactBias : ArtifactBias 
    {
        private WarriorArtifactBias(SaveGame saveGame) : base(saveGame) { }
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Str)
            {
                item.RandartItemCharacteristics.Str = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            else if (!item.RandartItemCharacteristics.Con)
            {
                item.RandartItemCharacteristics.Con = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            else if (!item.RandartItemCharacteristics.Dex)
            {
                item.RandartItemCharacteristics.Dex = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyRandomResistances(Item item)
        {
            if (Program.Rng.DieRoll(3) != 1 && !item.RandartItemCharacteristics.ResFear)
            {
                item.RandartItemCharacteristics.ResFear = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(3) == 1 && !item.RandartItemCharacteristics.NoMagic)
            {
                item.RandartItemCharacteristics.NoMagic = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override int ActivationPowerChance => 80;
        public override Activation GetActivationPowerType(Item item)
        {
            if (Program.Rng.DieRoll(100) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<InvulnActivation>();

            }
            else
            {
                return SaveGame.SingletonRepository.Activations.Get<BerserkActivation>();
            }
        }
    }
}
