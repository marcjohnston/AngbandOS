// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a widget that renders the players maximum mana value.
/// </summary>
[Serializable]
internal class MaxManaWidget : IntTextWidget
{
    private MaxManaWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 7;
    public override int Y => 25;
    public override int Width => 5;
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string IntValueName => nameof(MaxManaIntProperty);
    public override string JustificationName => nameof(RightJustification);
}
