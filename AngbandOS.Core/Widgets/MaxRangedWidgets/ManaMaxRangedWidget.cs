// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a widget that renders the current mana integer value in varying color based on the percentage of mana the player has to their maximum.
/// </summary>
[Serializable]
internal class ManaMaxRangedWidget : MaxRangedWidget
{
    private ManaMaxRangedWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 7;
    public override int Y => 26;
    public override int Width => 5;
    protected override ColorEnum DefaultColor => ColorEnum.BrightRed;
    public override string IntValueName => nameof(ManaIntProperty);
    public override string MaxIntValueName => nameof(MaxManaIntProperty);
    public override string JustificationName => nameof(RightJustification);

    public override (int, ColorEnum)[] Ranges => new (int, ColorEnum)[]
    {
        (100, ColorEnum.BrightGreen),
        (40, ColorEnum.BrightYellow),
        (20, ColorEnum.Orange)
    };
}
