// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class HealthPointsMaxRangedWidget : MaxRangedWidget
{
    private HealthPointsMaxRangedWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 7;
    public override int Y => 24;
    public override int Width => 5;
    protected override ColorEnum DefaultColor => ColorEnum.BrightRed;
    public override string IntValueName => nameof(HealthPointsIntProperty);
    public override string MaxIntValueName => nameof(MaxHealthPointsIntProperty);
    public override string JustificationName => nameof(RightJustification);

    public override (int, string?, ColorEnum)[] Ranges => new (int, string?, ColorEnum)[]
    {
        (100, null, ColorEnum.BrightGreen),
        (40, null, ColorEnum.BrightYellow),
        (20, null, ColorEnum.Orange)
    };
    public override string[]? ChangeTrackerNames => new string[] { nameof(HealthPointsIntProperty), nameof(MaxHealthPointsIntProperty) }; // TODO: Why do we need to watch the max health also
}
