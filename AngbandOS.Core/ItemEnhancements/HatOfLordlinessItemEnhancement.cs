// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class HatOfLordlinessItemEnhancement : ItemEnhancement
{
    private HatOfLordlinessItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override bool Cha => true;
    public override int? AdditiveBundleValue => 2000;
    public override string? FriendlyName => "of Lordliness";
    protected override string? BonusCharismaRollExpression => "1d3";
    protected override string? BonusWisdomRollExpression => "1d3";
    public override int TreasureRating => 17;
    public override bool SustCha => true;
    public override bool SustWis => true;
    public override bool Wis => true;
}
