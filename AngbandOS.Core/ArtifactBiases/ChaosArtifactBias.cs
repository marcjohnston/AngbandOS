namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class ChaosArtifactBias : ArtifactBias
    {
        private ChaosArtifactBias(SaveGame saveGame) : base(saveGame) { }

        public override bool ApplyRandomResistances(Item item)
        {
            if (!item.RandartItemCharacteristics.ResChaos)
            {
                item.RandartItemCharacteristics.ResChaos = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandartItemCharacteristics.ResConf)
            {
                item.RandartItemCharacteristics.ResConf = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandartItemCharacteristics.ResDisen)
            {
                item.RandartItemCharacteristics.ResDisen = false;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.Teleport)
            {
                item.RandartItemCharacteristics.Teleport = true;
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
                if (!item.RandartItemCharacteristics.Chaotic)
                {
                    item.RandartItemCharacteristics.Chaotic = true;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override int ActivationPowerChance => 50;

        public override Activation GetActivationPowerType(Item item)
        {
            if (Program.Rng.DieRoll(6) == 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<SummonDemonActivation>();
            }
            else
            {
                return SaveGame.SingletonRepository.Activations.Get<CallChaosActivation>();
            }
        }
    }
}
