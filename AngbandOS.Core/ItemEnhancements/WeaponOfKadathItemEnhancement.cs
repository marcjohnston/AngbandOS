// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class WeaponOfKadathItemEnhancement : ItemEnhancement
{
    private WeaponOfKadathItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override bool Con => true;
    public override int? Value => 20000;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string? FriendlyName => "of Kadath";
    protected override string? BonusConstitutionRollExpression => "1d2";
    protected override string? BonusDexterityRollExpression => "1d2";
    protected override string? BonusStrengthRollExpression => "1d2";
    protected override string? BonusDamageRollExpression => "1d5";
    protected override string? BonusHitRollExpression => "1d5";
    public override int TreasureRating => 20;
    public override bool SeeInvis => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
}