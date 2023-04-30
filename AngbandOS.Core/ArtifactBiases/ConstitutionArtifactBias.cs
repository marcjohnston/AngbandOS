namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class ConstitutionArtifactBias : ArtifactBias
    {
        private ConstitutionArtifactBias(SaveGame saveGame) : base(saveGame) { }
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Con)
            {
                item.RandartItemCharacteristics.Con = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.SustCon)
            {
                item.RandartItemCharacteristics.SustCon = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
