// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfInfravisionItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Value => 500;
    public override string? FriendlyName => "of Infravision";
    public override bool HideType => true;
    public override bool Infra => true;
    public override string? BonusInfravisionRollExpression => "1d5";
    public override int TreasureRating => 11;
}
