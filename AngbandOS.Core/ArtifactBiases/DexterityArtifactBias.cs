namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class DexterityArtifactBias : ArtifactBias
    {
        private DexterityArtifactBias(SaveGame saveGame) : base(saveGame) { }
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Dex)
            {
                item.RandartItemCharacteristics.Dex = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.SustDex)
            {
                item.RandartItemCharacteristics.SustDex = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
