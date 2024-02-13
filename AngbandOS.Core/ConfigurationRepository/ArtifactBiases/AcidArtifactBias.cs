// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (SaveGame.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandartItemCharacteristics.ImAcid)
        {
            item.RandartItemCharacteristics.ImAcid = true;
            if (SaveGame.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplySlaying(Item item)
    {
        if (item.Factory.CanApplyArtifactBiasSlaying)
        {
            if (!item.RandartItemCharacteristics.BrandAcid)
            {
                item.RandartItemCharacteristics.BrandAcid = true;
                if (SaveGame.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
