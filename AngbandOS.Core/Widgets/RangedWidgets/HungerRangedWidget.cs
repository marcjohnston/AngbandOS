// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class HungerRangedWidget : RangedWidget
{
    private HungerRangedWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 0;
    public override int Y => 44;
    public override int? Width => 6;
    protected override ColorEnum DefaultColor => ColorEnum.BrightRed;
    protected override string DefaultText => "Dead";
    public override string IntValueName => nameof(FoodIntProperty);

    public override (int, string, ColorEnum)[] Ranges => new (int, string, ColorEnum)[]
    {
        (Constants.PyFoodMax, "Gorged", ColorEnum.Green),
        (Constants.PyFoodFull, "Full", ColorEnum.BrightGreen),
        (Constants.PyFoodAlert, "", ColorEnum.BrightGreen),
        (Constants.PyFoodWeak, "Hungry", ColorEnum.Yellow),
        (Constants.PyFoodFaint, "Weak", ColorEnum.Orange),
        (0, "Weak", ColorEnum.Red)
    };
    public override string[]? ChangeTrackerNames => new string[] { nameof(FoodIntProperty) };
}
