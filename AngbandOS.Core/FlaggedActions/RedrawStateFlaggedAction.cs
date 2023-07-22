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
    public RedrawStateFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        ColourEnum attr = ColourEnum.White;
        string text;
        if (SaveGame.TimedParalysis.TurnsRemaining > 0)
        {
            attr = ColourEnum.Red;
            text = "Paralyzed!";
        }
        else if (SaveGame.Resting != 0)
        {
            text = "Rest ";
            if (SaveGame.Resting > 0)
            {
                text += SaveGame.Resting.ToString().PadLeft(5);
            }
            else if (SaveGame.Resting == -1)
            {
                text += "*****";
            }
            else if (SaveGame.Resting == -2)
            {
                text += "&&&&&";
            }
            else
            {
                text += "?????";
            }
        }
        else if (SaveGame.CommandRepeat != 0)
        {
            if (SaveGame.CommandRepeat > 999)
            {
                text = "Rep. " + SaveGame.CommandRepeat.ToString().PadRight(5);
            }
            else
            {
                text = "Repeat " + SaveGame.CommandRepeat.ToString().PadRight(3);
            }
        }
        else if (SaveGame.IsSearching)
        {
            text = "Searching ";
        }
        else
        {
            text = "          ";
        }
        SaveGame.Screen.Print(attr, text, RowState, ColState);
    }
}
