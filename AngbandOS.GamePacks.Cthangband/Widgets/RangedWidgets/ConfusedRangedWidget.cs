﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ConfusedRangedWidget : RangedWidgetGameConfiguration
{
    public override int X => 15;
    public override int Y => 44;
    public override int? Width => 8;
    public override string IntValueName => nameof(TimersEnum.ConfusingTimer);

    public override (int, string, ColorEnum)[] Ranges => new (int, string, ColorEnum)[]
    {
        (1, "Confused", ColorEnum.Orange),
    };
    public override string[]? ChangeTrackerNames => new string[] { nameof(TimersEnum.ConfusingTimer) };
}
