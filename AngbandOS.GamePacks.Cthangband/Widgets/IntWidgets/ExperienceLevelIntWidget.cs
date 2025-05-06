// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents the widget used to render the experience level of the player when the experience level of the player is at the maximum level that the player has attained.
/// </summary>
[Serializable]
public class ExperienceLevelIntWidget : IntWidgetGameConfiguration
{
    public override int X => 6;
    public override int Y => 5;
    public override int? Width => 6;
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string IntValueName => nameof(PropertiesEnum.ExperienceLevelIntProperty);
    public override string JustificationName => nameof(JustificationsEnum.RightJustification);
    public override string[]? ChangeTrackerNames => new string[] { nameof(PropertiesEnum.ExperienceLevelIntProperty) };
}
