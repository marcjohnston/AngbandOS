// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class HatOfWisdomRareItem : ItemAdditiveBundle
{
    private HatOfWisdomRareItem(Game game) : base(game) { } // This object is a singleton.
    public override int? AdditiveBundleValue => 500;
    public override string? FriendlyName => "of Wisdom";
    protected override string? BonusWisdomRollExpression => "1d2";
    public override int TreasureRating => 13;
    public override bool SustWis => true;
    public override bool Wis => true;
}
