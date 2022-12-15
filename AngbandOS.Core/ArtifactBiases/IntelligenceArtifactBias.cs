namespace AngbandOS.ArtifactBiases
{
    internal class IntelligenceArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (!item.RandartItemCharacteristics.Int)
            {
                item.RandartItemCharacteristics.Int = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.SustInt)
            {
                item.RandartItemCharacteristics.SustInt = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
