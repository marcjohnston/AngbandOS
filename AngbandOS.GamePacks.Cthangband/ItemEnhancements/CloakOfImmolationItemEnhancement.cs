// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfImmolationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Value => 4000;
    public override string? FriendlyName => "of Immolation";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreFire => true;
    public override string? BonusArmorClass => "1d4";
    public override int? TreasureRating => 16;
    public override bool? ResFire => true;
    public override bool? ShFire => true;
}
