// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawMapFlaggedAction : FlaggedAction
{
    private RedrawMapFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        // Save the cursor visible state, we will temporarily reset it.
        bool v = SaveGame.Screen.CursorVisible;

        // Turn off the cursor visible.
        SaveGame.Screen.CursorVisible = false; // TODO: Is this really needed, if we have a double-buffer?
        for (int y = SaveGame.PanelRowMin; y <= SaveGame.PanelRowMax; y++)
        {
            for (int x = SaveGame.PanelColMin; x <= SaveGame.PanelColMax; x++)
            {
                SaveGame.MapInfo(y, x, out ColorEnum a, out char c);
                if (SaveGame.TimedInvulnerability.Value != 0)
                {
                    a = ColorEnum.White;
                }
                else if (SaveGame.TimedEtherealness.Value != 0)
                {
                    a = ColorEnum.Black;
                }
                SaveGame.Screen.Print(a, c, y - SaveGame.PanelRowPrt, x - SaveGame.PanelColPrt);
            }
        }
        SaveGame.RedrawSingleLocation(SaveGame.MapY, SaveGame.MapX);

        // Restore the cursor visible.
        SaveGame.Screen.CursorVisible = v;
    }
}
