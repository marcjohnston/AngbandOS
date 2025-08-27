// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class IntelligenceArtifactBias : ArtifactBias
{
    private IntelligenceArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Intelligence";

    public override bool ApplyRandomArtifactBonuses(EffectiveAttributeSet characteristics)
    {
        if (characteristics.BonusIntelligence == 0)
        {
            characteristics.BonusIntelligence = Game.EnchantBonus(characteristics.BonusIntelligence);
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(EffectiveAttributeSet characteristics)
    {
        if (!characteristics.SustInt)
        {
            characteristics.SetBoolAttributeValue(AttributeEnum.SustInt, true);
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }
}
