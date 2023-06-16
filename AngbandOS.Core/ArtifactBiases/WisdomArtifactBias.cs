namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class WisdomArtifactBias : ArtifactBias
{
    private WisdomArtifactBias(SaveGame saveGame) : base(saveGame) { }
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
