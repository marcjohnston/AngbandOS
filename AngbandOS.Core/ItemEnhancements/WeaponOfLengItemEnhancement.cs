// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class WeaponOfLengItemEnhancement : ItemEnhancement
{
    private WeaponOfLengItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override bool Aggravate => true;
    public override int? AdditiveBundleValue => 0;
    public override bool IsCursed => true;
    public override string? FriendlyName => "of Leng";
    public override bool HeavyCurse => true;
    protected override string? BonusArmorClassRollExpression => "1d10";
    protected override string? BonusDamageRollExpression => "1d20";
    protected override string? BonusHitRollExpression => "1d20";
    public override int TreasureRating => 0;
    public override bool SeeInvis => true;
}
