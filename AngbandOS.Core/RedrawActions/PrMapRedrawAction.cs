namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrMapRedrawAction : RedrawAction
    {
        public PrMapRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void RedrawNow()
        {
            bool v = SaveGame.CursorVisible;
            SaveGame.CursorVisible = false;
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
                    SaveGame.Print(a, c, y - SaveGame.Level.PanelRowPrt, x - SaveGame.Level.PanelColPrt);
                }
            }
            SaveGame.Level.RedrawSingleLocation(SaveGame.Player.MapY, SaveGame.Player.MapX);
            SaveGame.CursorVisible = v;
        }
    }
}
