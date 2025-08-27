// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class StrengthArtifactBias : ArtifactBias
{
    private StrengthArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Strength";

    public override bool ApplyRandomArtifactBonuses(EffectiveAttributeSet characteristics)
    {
        if (characteristics.BonusStrength == 0)
        {
            characteristics.BonusStrength = Game.EnchantBonus(characteristics.BonusStrength);
            if (Game.DieRoll(2) == 1) // 50% chance of being a "free" power
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(EffectiveAttributeSet characteristics)
    {
        if (!characteristics.SustStr)
        {
            characteristics.SetBoolAttributeValue(AttributeEnum.SustStr, true);
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }
}
