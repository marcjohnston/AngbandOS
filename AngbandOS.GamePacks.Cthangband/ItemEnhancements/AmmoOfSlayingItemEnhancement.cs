// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfSlayingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Value => 20;
    public override string? FriendlyName => "of Slaying";
    public override string? BonusDamageRollExpression => "1d12";
    public override string? BonusHitRollExpression => "1d12";
    public override int TreasureRating => 15;
}
