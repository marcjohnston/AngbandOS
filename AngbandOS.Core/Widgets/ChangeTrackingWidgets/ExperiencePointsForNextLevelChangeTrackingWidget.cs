// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a change tracking widget to render the experience points for the player to attain the next experience level.  When the experience points needed
/// for the next level changes, the <see cref="ExperiencePointsForNextLevelConditionalWidget"/> widget is rendered.
/// </summary>
[Serializable]
internal class ExperiencePointsForNextLevelChangeTrackingWidget : ChangeTrackingWidget
{
    private ExperiencePointsForNextLevelChangeTrackingWidget(Game game) : base(game) { } // This object is a singleton.
    public override string ChangeTrackingName => nameof(ExperiencePointsForNextLevelFunction);
    public override string[] WidgetNames => new string[] { nameof(ExperiencePointsAtMaxConditionalWidget) };
}
