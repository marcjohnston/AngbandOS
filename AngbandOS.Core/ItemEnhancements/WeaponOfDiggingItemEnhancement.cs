// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class WeaponOfDiggingItemEnhancement : ItemEnhancement
{
    private WeaponOfDiggingItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override bool BrandAcid => true;
    public override int? Value => 500;
    public override string? FriendlyName => "of Digging";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    protected override string? BonusTunnelRollExpression => "1d5";
    public override int TreasureRating => 4;
    public override bool Tunnel => true;
}