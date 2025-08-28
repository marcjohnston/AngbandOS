// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfSeeingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Value => 1000;
    public override string? FriendlyName => "of Seeing";
    public override string? BonusSearchRollExpression => "1d5";
    public override int? TreasureRating => 8;
    public override bool? ResBlind => true;
    public override bool? SeeInvis => true;
}
