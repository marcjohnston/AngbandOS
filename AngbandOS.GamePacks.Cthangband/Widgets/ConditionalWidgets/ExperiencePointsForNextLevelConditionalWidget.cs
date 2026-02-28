// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a conditional widget to render the experience points for the player to attain the next experience level.  When the player has lost one or more
/// experience points needed, the <see cref="ExperiencePointsForNextLevelLostIntWidget"/> widget is rendered; otherwise the <see cref="ExperiencePointsForNextLevelIntWidget"/>
/// widget is rendered.
/// </summary>
[Serializable]
public class ExperiencePointsForNextLevelConditionalWidget : ConditionalWidgetGameConfiguration
{
    public override string ProductOfSumsBoolFunctionKey => nameof(ExperiencePointsForNextLevelProductOfSumsConditional);
    public override string[]? TrueWidgetNames => new string[] { nameof(ExperiencePointsForNextLevelLostIntWidget) };
    public override string[]? FalseWidgetNames => new string[] { nameof(ExperiencePointsForNextLevelIntWidget) };
}
