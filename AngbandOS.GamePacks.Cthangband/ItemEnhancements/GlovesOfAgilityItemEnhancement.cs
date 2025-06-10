// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlovesOfAgilityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Value => 1000;
    public override bool Dex => true;
    public override string? FriendlyName => "of Agility";
    public override bool HideType => true;
    public override string? BonusDexterityRollExpression => "1d5";
    public override int TreasureRating => 14;
}
