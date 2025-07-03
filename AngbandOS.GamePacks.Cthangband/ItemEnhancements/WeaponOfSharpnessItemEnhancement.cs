// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSharpnessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Value => 5000;
    public override string? FriendlyName => "of Sharpness";
    public override int TreasureRating => 20;
    public override bool Tunnel => true;
    public override bool Vorpal => true;
}
