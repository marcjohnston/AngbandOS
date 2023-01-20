namespace AngbandOS.Core.FlaggedActions
{
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
                    SaveGame.Level.MapInfo(y, x, out Colour a, out char c);
                    if (SaveGame.Player.TimedInvulnerability.TimeRemaining != 0)
                    {
                        a = Colour.White;
                    }
                    else if (SaveGame.Player.TimedEtherealness.TimeRemaining != 0)
                    {
                        a = Colour.Black;
                    }
                    SaveGame.Screen.Print(a, c, y - SaveGame.Level.PanelRowPrt, x - SaveGame.Level.PanelColPrt);
                }
            }
            SaveGame.Level.RedrawSingleLocation(SaveGame.Player.MapY, SaveGame.Player.MapX);

            // Restore the cursor visible.
            SaveGame.Screen.CursorVisible = v;
        }
    }
}
