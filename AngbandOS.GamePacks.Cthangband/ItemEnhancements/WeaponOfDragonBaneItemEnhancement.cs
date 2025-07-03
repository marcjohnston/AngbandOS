// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfDragonBaneItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Con => true;
    public override int Value => 6000;
    public override string? FriendlyName => "of Dragon Bane";
    public override bool KillDragon => true;
    public override string? BonusConstitutionRollExpression => "1d1";
    public override int TreasureRating => 24;
    public override bool SlayDragon => true;
}
