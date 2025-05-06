// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a widget that renders the "DTrap" trap detector in green, when the North, South, East and West map grid coordinates from the player are within the
/// boundaries of the traps detected area.  This widget is a child of the true branch of the <see cref="TrapDetectionConditionalWidget"/> widget.
/// </summary>
[Serializable]
public class TrapCountRangedWidget : RangedWidgetGameConfiguration
{
    public override int X => 53;
    public override int Y => 44;
    public override int? Width => 5;
    public override ColorEnum DefaultColor => ColorEnum.Yellow;
    public override string DefaultText => "DTRAP";
    public override string IntValueName => nameof(FunctionsEnum.TrapCountFunction);
    public override (int startValue, string textToRender, ColorEnum color)[] Ranges => new (int, string, ColorEnum)[]
    {
        (4, "DTrap", ColorEnum.Green)
    };
}
