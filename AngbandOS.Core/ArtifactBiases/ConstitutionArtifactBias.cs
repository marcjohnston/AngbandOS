// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class ConstitutionArtifactBias : ArtifactBias
{
    private ConstitutionArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Constitution";

    public override bool ApplyRandomArtifactBonuses(EffectiveAttributeSet characteristics)
    {
        if (characteristics.Constitution == 0)
        {
            characteristics.Constitution = Game.EnchantBonus(characteristics.Constitution);
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(EffectiveAttributeSet characteristics)
    {
        if (!characteristics.SustCon)
        {
            characteristics.SustCon = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }
}
