// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a conditional widget that renders a friendly status when the player is tracking a monster and the monster is sleeping; otherwise the <see cref="TrackedMonsterHealthIsFriendlyConditionalWidget"/> 
/// widget is rendered.
/// </summary>
[Serializable]
public class TrackedMonsterHealthIsSleepingConditionalWidget : ConditionalWidgetGameConfiguration
{
    public override (string conditionalName, bool isTrue, int term)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.TrackedMonsterIsSleepingBoolFunction), true, 0)
    };
    public override string[]? TrueWidgetNames => new string[] { nameof(TrackedMonsterHealthIsSleepingTextWidget) };
    public override string[]? FalseWidgetNames => new string[] { nameof(TrackedMonsterHealthIsFriendlyConditionalWidget) };
}
