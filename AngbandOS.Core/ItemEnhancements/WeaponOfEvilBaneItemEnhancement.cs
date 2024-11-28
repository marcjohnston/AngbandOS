// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class WeaponOfEvilBaneItemEnhancement : ItemEnhancement
{
    private WeaponOfEvilBaneItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override bool Blessed => true;
    public override int? Value => 5000;
    public override string? FriendlyName => "of Evil Bane";
    protected override string? BonusWisdomRollExpression => "1d2";
    public override int TreasureRating => 20;
    public override bool SlayEvil => true;
    public override bool Wis => true;
}
