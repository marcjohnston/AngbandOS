// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfNaivetyItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Value => 0;
    public override string? FriendlyName => "of Naivety";
    public override string? BonusWisdomRollExpression => "1d5";
    public override int TreasureRating => 0;
    public override bool Wis => true;
}
