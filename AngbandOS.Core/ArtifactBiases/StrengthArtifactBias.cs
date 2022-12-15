namespace AngbandOS.ArtifactBiases
{
    internal class StrengthArtifactBias : ArtifactBias
    {
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
            return false;
        }
        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.SustStr)
            {
                item.RandartItemCharacteristics.SustStr = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
