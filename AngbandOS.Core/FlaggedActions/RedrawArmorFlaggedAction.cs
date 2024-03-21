// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawArmorFlaggedAction : FlaggedAction
{
    private const int ColAc = 0;
    private const int RowAc = 22;
    private RedrawArmorFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        Game.Screen.Print("Cur AC ", RowAc, ColAc);
        string tmp = (Game.DisplayedBaseArmorClass.Value + Game.DisplayedArmorClassBonus.Value).ToString().PadLeft(5);
        Game.Screen.Print(ColorEnum.BrightGreen, tmp, RowAc, ColAc + 7);
    }
}
