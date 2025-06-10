// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a text widget that renders asterisks when the player has attained the maximum number of experience points.
/// </summary>
[Serializable]
public class ExperiencePointsAtMaxTextWidget : TextWidgetGameConfiguration
{
    public override int X => 4;
    public override int Y => 6;
    public override int? Width => 8;
    public override string Text => "   *****";
    public override string JustificationName => nameof(JustificationsEnum.RightJustification);
    public override ColorEnum Color => ColorEnum.BrightGreen;
}
