// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfLawItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Value => 25000;
    public override bool? FreeAct => true;
    public override string? FriendlyName => "(Weapon of Law)";
    public override string? Constitution => "1d2";
    public override string? Strength => "1d2";
    public override string? Damage => "1d6";
    public override string? Hits => "1d6";
    public override int? TreasureRating => 26;
    public override bool? SeeInvis => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlayUndead => true;
}
