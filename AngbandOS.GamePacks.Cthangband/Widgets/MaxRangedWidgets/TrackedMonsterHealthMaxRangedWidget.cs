// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TrackedMonsterHealthMaxRangedWidget : MaxRangedWidgetGameConfiguration
{
    public override int X => 0;

    public override int Y => 32;

    public override ColorEnum DefaultColor => ColorEnum.Red;
    public override string IntValueName => nameof(FunctionsEnum.TrackedMonsterHealthIntFunction);
    public override string MaxIntValueName => nameof(FunctionsEnum.TrackedMonsterMaxHealthIntFunction);

    public override (int, string?, ColorEnum)[] Ranges => new (int, string?, ColorEnum)[]
    {
        (100, "[**********]", ColorEnum.BrightGreen),
        ( 90, "[*********-]", ColorEnum.Yellow),
        ( 80, "[********--]", ColorEnum.Yellow),
        ( 70, "[*******---]", ColorEnum.Yellow),
        ( 60, "[******----]", ColorEnum.Yellow),
        ( 50, "[*****-----]", ColorEnum.Orange),
        ( 40, "[****------]", ColorEnum.Orange),
        ( 30, "[***-------]", ColorEnum.Orange),
        ( 25, "[**--------]", ColorEnum.Orange),
        ( 20, "[**--------]", ColorEnum.BrightRed),
        ( 10, "[*---------]", ColorEnum.BrightRed),
        (  0, "[----------]", ColorEnum.BrightRed),
    };
}