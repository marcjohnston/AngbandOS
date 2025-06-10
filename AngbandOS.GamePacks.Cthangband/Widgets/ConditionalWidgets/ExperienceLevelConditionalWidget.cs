// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents the widget used to render either the <see cref="ExperienceLevelLostIntWidget"/> widget when the player has lost one or more levels of expereience or the 
/// <see cref="ExperienceLevelIntWidget"/> widget when the experience level of the player is at the maximum level that the player has attained.
/// </summary>
[Serializable]
public class ExperienceLevelConditionalWidget : ConditionalWidgetGameConfiguration
{
    public override (string conditionalName, bool isTrue, int term)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.ExperienceLevelsLostFunction), true, 0)
    };

    public override string[]? TrueWidgetNames => new string[] { nameof(ExperienceLevelLostIntWidget), nameof(ExperienceLevelLostLabelTextWidget) };

    public override string[]? FalseWidgetNames => new string[] { nameof(ExperienceLevelIntWidget), nameof(ExperienceLevelLabelTextWidget) };
}
