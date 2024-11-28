// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class BowOfAccuracyItemEnhancement : ItemEnhancement
{
    private BowOfAccuracyItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override int? Value => 1000;
    public override string? FriendlyName => "of Accuracy";
    protected override string? BonusDamageRollExpression => "1d5";
    protected override string? BonusHitRollExpression => "1d15";
    public override int TreasureRating => 10;
}
