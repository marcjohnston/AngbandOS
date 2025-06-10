// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a widget that renders the trap detection as blank.  This widget is a child for the false branch of the <see cref="TrapDetectionConditionalWidget"/> widget.
/// </summary>
[Serializable]
public class NoTrapsDetectedTextWidget : TextWidgetGameConfiguration
{
    public override int X => 53;
    public override int Y => 44;
    public override int? Width => 5;
    public override string Text => "";
}
