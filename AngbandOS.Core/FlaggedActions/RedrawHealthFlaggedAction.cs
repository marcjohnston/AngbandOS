namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawHealthFlaggedAction : FlaggedAction
    {
        private const int RowInfo = 32;
        private const int ColInfo = 0;
        public RedrawHealthFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            if (SaveGame.TrackedMonsterIndex == 0)
            {
                SaveGame.Screen.Erase(RowInfo, ColInfo, 12);
                SaveGame.Screen.Erase(RowInfo - 3, ColInfo, 12);
                SaveGame.Screen.Erase(RowInfo - 2, ColInfo, 12);
                SaveGame.Screen.Erase(RowInfo - 1, ColInfo, 12);
            }
            else if (!SaveGame.Level.Monsters[SaveGame.TrackedMonsterIndex].IsVisible)
            {
                SaveGame.Screen.Print(Colour.White, "[----------]", RowInfo, ColInfo);
            }
            else if (SaveGame.Player.TimedHallucinations.TimeRemaining != 0)
            {
                SaveGame.Screen.Print(Colour.White, "[----------]", RowInfo, ColInfo);
            }
            else if (SaveGame.Level.Monsters[SaveGame.TrackedMonsterIndex].Health < 0)
            {
                SaveGame.Screen.Print(Colour.White, "[----------]", RowInfo, ColInfo);
            }
            else
            {
                Monster mPtr = SaveGame.Level.Monsters[SaveGame.TrackedMonsterIndex];
                Colour attr = Colour.Red;
                string smb = "**********";
                int pct = 100 * mPtr.Health / mPtr.MaxHealth;
                if (pct >= 10)
                {
                    attr = Colour.BrightRed;
                }
                if (pct >= 25)
                {
                    attr = Colour.Orange;
                }
                if (pct >= 60)
                {
                    attr = Colour.Yellow;
                }
                if (pct >= 100)
                {
                    attr = Colour.BrightGreen;
                }
                if (mPtr.FearLevel != 0)
                {
                    attr = Colour.Purple;
                    smb = "AFRAID****";
                }
                if (mPtr.SleepLevel != 0)
                {
                    attr = Colour.Blue;
                    smb = "SLEEPING**";
                }
                if (mPtr.SmFriendly)
                {
                    attr = Colour.BrightBrown;
                    smb = "FRIENDLY**";
                }
                int len = pct < 10 ? 1 : pct < 90 ? (pct / 10) + 1 : 10;
                SaveGame.Screen.Print(Colour.White, "[----------]", RowInfo, ColInfo);
                SaveGame.Screen.Print(attr, smb.Substring(0, len), RowInfo, ColInfo + 1);
                SaveGame.Screen.Print(Colour.White, mPtr.Race.SplitName1, RowInfo - 3, ColInfo);
                SaveGame.Screen.Print(Colour.White, mPtr.Race.SplitName2, RowInfo - 2, ColInfo);
                SaveGame.Screen.Print(Colour.White, mPtr.Race.SplitName3, RowInfo - 1, ColInfo);
            }
        }
    }
}
