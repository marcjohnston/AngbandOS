// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class WeaponOfLawItemEnhancement : ItemEnhancement
{
    private WeaponOfLawItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override bool Con => true;
    public override int? AdditiveBundleValue => 25000;
    public override bool FreeAct => true;
    public override string? FriendlyName => "(Weapon of Law)";
    protected override string? BonusConstitutionRollExpression => "1d2";
    protected override string? BonusStrengthRollExpression => "1d2";
    protected override string? BonusDamageRollExpression => "1d6";
    protected override string? BonusHitRollExpression => "1d6";
    public override int TreasureRating => 26;
    public override bool SeeInvis => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
}
