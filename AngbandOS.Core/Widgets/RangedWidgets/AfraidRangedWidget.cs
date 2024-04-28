// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a widget that renders an afraid status of the player.
/// </summary>
[Serializable]
internal class AfraidRangedWidget : RangedWidget
{
    private AfraidRangedWidget(Game game) : base(game)
    {
    } // This object is a singleton.
    public override int X => 25;
    public override int Y => 44;
    public override int Width => 6;
    public override string IntValueName => nameof(FearTimer);
    public override (int, string, ColorEnum)[] Ranges => new (int, string, ColorEnum)[]
    {
        (1, "Afraid", ColorEnum.Orange),
    };
}
