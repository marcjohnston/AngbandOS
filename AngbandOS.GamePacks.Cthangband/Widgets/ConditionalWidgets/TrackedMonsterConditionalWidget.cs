// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a conditional widget that renders the monster name and status when the player is tracking a monster.
/// </summary>
[Serializable]
public class TrackedMonsterConditionalWidget : ConditionalWidgetGameConfiguration
{
    public override string ProductOfSumsBoolFunctionKey => nameof(TrackedMonsterProductOfSumsConditional);

    public override string[]? TrueWidgetNames => new string[] { nameof(TrackedMonsterRaceNameTextWidget), nameof(TrackedMonsterHealthIsInvisibleConditionalWidget) };
    public override string[]? FalseWidgetNames => new string[] { nameof(TrackedMonsterRaceNameTextWidget), nameof(NoTrackedMonsterHealthLabelWidget) };
    public override string[]? ChangeTrackerNames => new string[] { nameof(FunctionsEnum.PlayerIsTrackingMonsterBoolFunction) };
}
