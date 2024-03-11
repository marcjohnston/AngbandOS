// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawCutFlaggedAction : FlaggedAction
{
    private const int RowCut = 43;
    private const int ColCut = 13;
    private RedrawCutFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        int c = SaveGame.TimedBleeding.Value;
        if (c > 1000)
        {
            SaveGame.Screen.Print(ColorEnum.BrightRed, "Mortal wound", RowCut, ColCut);
        }
        else if (c > 200)
        {
            SaveGame.Screen.Print(ColorEnum.Red, "Deep gash   ", RowCut, ColCut);
        }
        else if (c > 100)
        {
            SaveGame.Screen.Print(ColorEnum.Red, "Severe cut  ", RowCut, ColCut);
        }
        else if (c > 50)
        {
            SaveGame.Screen.Print(ColorEnum.Orange, "Nasty cut   ", RowCut, ColCut);
        }
        else if (c > 25)
        {
            SaveGame.Screen.Print(ColorEnum.Orange, "Bad cut     ", RowCut, ColCut);
        }
        else if (c > 10)
        {
            SaveGame.Screen.Print(ColorEnum.Yellow, "Light cut   ", RowCut, ColCut);
        }
        else if (c > 0)
        {
            SaveGame.Screen.Print(ColorEnum.Yellow, "Graze       ", RowCut, ColCut);
        }
        else
        {
            SaveGame.Screen.Print("            ", RowCut, ColCut);
        }
    }
}
