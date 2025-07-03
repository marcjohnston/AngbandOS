// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfLightItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Value => 500;
    public override string? FriendlyName => "of Light";
    public override int Radius => 3;
    public override int TreasureRating => 6;
    public override bool ResLight => true;
    }
