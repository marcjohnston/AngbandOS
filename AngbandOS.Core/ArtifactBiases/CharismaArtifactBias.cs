namespace AngbandOS.Core.ArtifactBiases
{
    [Serializable]
    internal class CharismaArtifactBias : ArtifactBias
    {
        private CharismaArtifactBias(SaveGame saveGame) : base(saveGame) { }
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Cha)
            {
                item.RandartItemCharacteristics.Cha = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.SustCha)
            {
                item.RandartItemCharacteristics.SustCha = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
