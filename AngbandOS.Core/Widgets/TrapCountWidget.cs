// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class TrapCountWidget : RangedWidget
{
    private TrapCountWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 53;
    public override int Y => 44;
    public override int Width => 5;
    protected override ColorEnum DefaultColor => ColorEnum.Yellow;
    protected override string DefaultText => "DTRAP";
    public override string IntChangeTrackingName => nameof(TrapCountFunction);
    public override (int startValue, string textToRender, ColorEnum color)[] Ranges => new (int, string, ColorEnum)[]
    {
        (4, "DTrap", ColorEnum.Green)
    };

    public override (string conditionalName, bool isTrue)[]? EnabledNames => new (string, bool)[]
    {
        (nameof(TrapsDetectedFunction), true)
    };
}