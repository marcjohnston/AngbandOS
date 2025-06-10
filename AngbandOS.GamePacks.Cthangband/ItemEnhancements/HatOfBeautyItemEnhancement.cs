// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfBeautyItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Cha => true;
    public override int? Value => 1000;
    public override string? FriendlyName => "of Beauty";
    public override string? BonusCharismaRollExpression => "1d4";
    public override int TreasureRating => 8;
    public override bool SustCha => true;
}
