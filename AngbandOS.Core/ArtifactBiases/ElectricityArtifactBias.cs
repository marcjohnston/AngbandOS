namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class ElectricityArtifactBias : ArtifactBias
    {
        private ElectricityArtifactBias(SaveGame saveGame) : base(saveGame) { }
        public override bool ApplyRandomResistances(Item item)
        {
            if (!item.RandartItemCharacteristics.ResElec)
            {
                item.RandartItemCharacteristics.ResElec = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (item.Category >= ItemTypeEnum.Cloak && item.Category <= ItemTypeEnum.HardArmor && !item.RandartItemCharacteristics.ShElec)
            {
                item.RandartItemCharacteristics.ShElec = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandartItemCharacteristics.ImElec)
            {
                item.RandartItemCharacteristics.ImElec = true;
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
                if (!item.RandartItemCharacteristics.BrandElec)
                {
                    item.RandartItemCharacteristics.BrandElec = true;
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
                return SaveGame.SingletonRepository.Activations.Get<BoElec1Activation>();
            }
            else if (Program.Rng.DieRoll(5) != 1)
            {
                return SaveGame.SingletonRepository.Activations.Get<BaElec2Activation>();
            }
            else
            {
                return SaveGame.SingletonRepository.Activations.Get<BaElec3Activation>();
            }
        }
    }
}
