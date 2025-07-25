// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfLengItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Aggravate => true;
    public override bool Valueless => true;
    public override bool IsCursed => true;
    public override string? FriendlyName => "of Leng";
    public override bool HeavyCurse => true;
    public override string? BonusArmorClassRollExpression => "1d10";
    public override string? BonusDamageRollExpression => "1d20";
    public override string? BonusHitRollExpression => "1d20";
    public override int TreasureRating => 0;
    public override bool SeeInvis => true;
}
