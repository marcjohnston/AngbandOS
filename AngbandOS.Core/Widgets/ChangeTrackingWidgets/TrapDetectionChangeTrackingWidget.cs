// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a widget that renders the traps detection widget when the trap detection .
/// </summary>
[Serializable]
internal class TrapDetectionChangeTrackingWidget : ChangeTrackingWidget
{
    private TrapDetectionChangeTrackingWidget(Game game) : base(game) { } // This object is a singleton.
    public override string ChangeTrackingName => nameof(TrapsDetectedFunction);
    public override string[] WidgetNames => new string[] { nameof(TrapDetectionConditionalWidget) };
}
