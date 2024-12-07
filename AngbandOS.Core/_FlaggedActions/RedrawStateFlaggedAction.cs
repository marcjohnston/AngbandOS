// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawStateFlaggedAction : FlaggedAction
{
    private const int ColState = 27;
    private const int RowState = 43;
    private RedrawStateFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        ColorEnum attr = ColorEnum.White;
        string text;
        if (Game.ParalysisTimer.Value > 0)
        {
            attr = ColorEnum.Red;
            text = "Paralyzed!";
        }
        else if (Game.Resting != 0)
        {
            text = "Rest ";
            if (Game.Resting > 0)
            {
                text += Game.Resting.ToString().PadLeft(5);
            }
            else if (Game.Resting == -1)
            {
                text += "*****";
            }
            else if (Game.Resting == -2)
            {
                text += "&&&&&";
            }
            else
            {
                text += "?????";
            }
        }
        else if (Game.CommandRepeat != 0)
        {
            if (Game.CommandRepeat > 999)
            {
                text = "Rep. " + Game.CommandRepeat.ToString().PadRight(5);
            }
            else
            {
                text = "Repeat " + Game.CommandRepeat.ToString().PadRight(3);
            }
        }
        else if (Game.IsSearching)
        {
            text = "Searching ";
        }
        else
        {
            text = "          ";
        }
        Game.Screen.Print(attr, text, RowState, ColState);
    }
}
