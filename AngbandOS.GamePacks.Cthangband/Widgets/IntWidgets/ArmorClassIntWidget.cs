﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ArmorClassIntWidget : IntWidgetGameConfiguration
{
    public override int X => 7;
    public override int Y => 22;
    public override int? Width => 5;
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string IntValueName => nameof(FunctionsEnum.ArmorClassIntFunction);
    public override string JustificationName => nameof(JustificationsEnum.RightJustification);
    public override string[]? ChangeTrackerNames => new string[] { nameof(FunctionsEnum.ArmorClassIntFunction) };
}