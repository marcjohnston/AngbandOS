namespace AngbandOS.ArtifactBiases
{
    internal class WisdomArtifactBias : ArtifactBias
    {
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

        public override bool ApplyMiscPowers(Item item)
        {
            if (!item.RandartItemCharacteristics.SustWis)
            {
                item.RandartItemCharacteristics.SustWis = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
