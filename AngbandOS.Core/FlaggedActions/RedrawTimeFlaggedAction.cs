﻿
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawTimeFlaggedAction : FlaggedAction
    {
        private const int ColDate = 0;
        private const int RowDate = 9;
        private const int ColTime = 0;
        private const int RowTime = 8;
        public RedrawTimeFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            SaveGame.Screen.Print(Colour.White, "Time", RowTime, ColTime);
            SaveGame.Screen.Print(Colour.White, "Day", RowDate, ColDate);
            SaveGame.Screen.Print(Colour.BrightGreen, SaveGame.Player.GameTime.TimeText.PadLeft(8), RowTime, ColTime + 4);
            SaveGame.Screen.Print(Colour.BrightGreen, SaveGame.Player.GameTime.DateText.PadLeft(8), RowDate, ColDate + 4);
        }
    }
}