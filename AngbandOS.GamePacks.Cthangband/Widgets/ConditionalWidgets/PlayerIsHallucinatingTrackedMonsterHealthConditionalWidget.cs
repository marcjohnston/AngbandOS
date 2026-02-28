// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a conditional widget that renders an unknown health gauge when the player is tracking a monster and the player is hallucinating; otherwise the <see cref="TrackedMonsterHealthIsAfraidConditionalWidget"/> 
/// widget is rendered.
/// </summary>
[Serializable]
public class PlayerIsHallucinatingTrackedMonsterHealthConditionalWidget : ConditionalWidgetGameConfiguration
{
    public override string ProductOfSumsBoolFunctionKey => nameof(PlayerIsHallucinatingTrackedMonsterHealthProductOfSumsBoolFunction);
    public override string[]? TrueWidgetNames => new string[] { nameof(TrackedMonsterHealthUnknownLabelWidget) };
    public override string[]? FalseWidgetNames => new string[] { nameof(TrackedMonsterHealthIsDeadConditionalWidget) };
}
