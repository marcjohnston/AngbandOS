// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawConfusedFlaggedAction : FlaggedAction
{
    private const int ColConfused = 15;
    private const int RowConfused = 44;
    public RedrawConfusedFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        if (SaveGame.TimedConfusion.TurnsRemaining > 0)
        {
            SaveGame.Screen.Print(ColourEnum.Orange, "Confused", RowConfused, ColConfused);
        }
        else
        {
            SaveGame.Screen.Print("        ", RowConfused, ColConfused);
        }
    }
}
