// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a widget that renders the mana label, the current max ranged value widget, the max mana label and the max mana value widgets, if the player has chosen a 
/// character that uses mana.
/// </summary>
[Serializable]
internal class ManaConditionalWidget : ConditionalWidget
{
    private ManaConditionalWidget(Game game) : base(game) { } // This object is a singleton.
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(UsesManaFunction), true, 0)
    };
    public override string[]? TrueWidgetNames => new string[] { nameof(ManaMaxRangedWidget), nameof(ManaLabelTextWidget), nameof(MaxManaLabelTextWidget), nameof(MaxManaIntWidget) };
}
