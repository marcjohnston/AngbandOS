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
    private AcidArtifactBias(Game game) : base(game) { }

    public override string AffinityName => "Acid";
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.Characteristics.ResAcid)
        {
            item.Characteristics.ResAcid = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (Game.DieRoll(ImmunityLuckOneInChance) == 1 && !item.Characteristics.ImAcid)
        {
            item.Characteristics.ImAcid = true;
            if (Game.DieRoll(2) == 1)
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
            if (!item.Characteristics.BrandAcid)
            {
                item.Characteristics.BrandAcid = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
