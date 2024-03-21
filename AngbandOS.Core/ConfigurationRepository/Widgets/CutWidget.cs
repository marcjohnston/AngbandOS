// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class CutWidget : RangedWidget
{
    private CutWidget(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override int X => 13;
    public override int Y => 43;
    public override int Width => 12;
    public override string IntChangeTrackingName => nameof(BleedingTimer);

    public override (int, string, ColorEnum)[] Ranges => new (int, string, ColorEnum)[]
    {
        (1000, "Mortal wound", ColorEnum.BrightRed),
        (201, "Deep gash", ColorEnum.Red),
        (101, "Severe cut", ColorEnum.Red),
        (51, "Nasty cut", ColorEnum.Orange),
        (26, "Bad cut", ColorEnum.Orange),
        (11, "Light cut", ColorEnum.Yellow),
        (1, "Graze", ColorEnum.Yellow)
    };
}
