// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class HatOfIntelligenceItemEnhancement : ItemEnhancement
{
    private HatOfIntelligenceItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override int? Value => 500;
    public override string? FriendlyName => "of Intelligence";
    public override bool Int => true;
    protected override string? BonusIntelligenceRollExpression => "1d2";
    public override int TreasureRating => 13;
    public override bool SustInt => true;
}
