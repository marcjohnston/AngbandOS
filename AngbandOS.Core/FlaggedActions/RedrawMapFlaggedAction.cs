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
    public RedrawMapFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        // Save the cursor visible state, we will temporarily reset it.
        bool v = SaveGame.Screen.CursorVisible;

        // Turn off the cursor visible.
        SaveGame.Screen.CursorVisible = false; // TODO: Is this really needed, if we have a double-buffer?
        for (int y = SaveGame.Level.PanelRowMin; y <= SaveGame.Level.PanelRowMax; y++)
        {
            for (int x = SaveGame.Level.PanelColMin; x <= SaveGame.Level.PanelColMax; x++)
            {
                SaveGame.Level.MapInfo(y, x, out ColourEnum a, out char c);
                if (SaveGame.TimedInvulnerability.TurnsRemaining != 0)
                {
                    a = ColourEnum.White;
                }
                else if (SaveGame.TimedEtherealness.TurnsRemaining != 0)
                {
                    a = ColourEnum.Black;
                }
                SaveGame.Screen.Print(a, c, y - SaveGame.Level.PanelRowPrt, x - SaveGame.Level.PanelColPrt);
            }
        }
        SaveGame.Level.RedrawSingleLocation(SaveGame.MapY, SaveGame.MapX);

        // Restore the cursor visible.
        SaveGame.Screen.CursorVisible = v;
    }
}
