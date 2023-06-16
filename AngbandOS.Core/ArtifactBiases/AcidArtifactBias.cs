namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class AcidArtifactBias : ArtifactBias
{
    private AcidArtifactBias(SaveGame saveGame) : base(saveGame) { }

    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandartItemCharacteristics.ResAcid)
        {
            item.RandartItemCharacteristics.ResAcid = true;
            if (Program.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (Program.Rng.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandartItemCharacteristics.ImAcid)
        {
            item.RandartItemCharacteristics.ImAcid = true;
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
            if (!item.RandartItemCharacteristics.BrandAcid)
            {
                item.RandartItemCharacteristics.BrandAcid = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
