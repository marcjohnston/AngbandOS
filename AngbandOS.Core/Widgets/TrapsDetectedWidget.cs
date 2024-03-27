// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class TrapsDetectedWidget : BoolWidget
{
    private TrapsDetectedWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 53;
    public override int Y => 44;
    public override int Width => 5;
    public override string BoolChangeTrackingName => nameof(TrapsDetectedFunction);
    public override string TrueValue => "";
    public override string FalseValue => "";

    /// <summary>
    /// Returns a tuple with the nameof the TrapsDetectedFunction and a value of false as the condition to render this widget.
    /// </summary>
    public override (string conditionalName, bool isTrue)[]? EnabledNames => new (string, bool)[]
    {
        (nameof(TrapsDetectedFunction), false)
    };
}
