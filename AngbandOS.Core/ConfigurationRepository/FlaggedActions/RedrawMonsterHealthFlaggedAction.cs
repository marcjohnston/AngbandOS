﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawMonsterHealthFlaggedAction : FlaggedAction
{
    private const int RowInfo = 32;
    private const int ColInfo = 0;
    private RedrawMonsterHealthFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        if (SaveGame.TrackedMonsterIndex == 0)
        {
            SaveGame.Screen.Erase(RowInfo, ColInfo, 12);
            SaveGame.Screen.Erase(RowInfo - 3, ColInfo, 12);
            SaveGame.Screen.Erase(RowInfo - 2, ColInfo, 12);
            SaveGame.Screen.Erase(RowInfo - 1, ColInfo, 12);
        }
        else if (!SaveGame.Monsters[SaveGame.TrackedMonsterIndex].IsVisible)
        {
            SaveGame.Screen.Print(ColorEnum.White, "[----------]", RowInfo, ColInfo);
        }
        else if (SaveGame.TimedHallucinations.Value != 0)
        {
            SaveGame.Screen.Print(ColorEnum.White, "[----------]", RowInfo, ColInfo);
        }
        else if (SaveGame.Monsters[SaveGame.TrackedMonsterIndex].Health < 0)
        {
            SaveGame.Screen.Print(ColorEnum.White, "[----------]", RowInfo, ColInfo);
        }
        else
        {
            Monster mPtr = SaveGame.Monsters[SaveGame.TrackedMonsterIndex];
            ColorEnum attr = ColorEnum.Red;
            string smb = "**********";
            int pct = 100 * mPtr.Health / mPtr.MaxHealth;
            if (pct >= 10)
            {
                attr = ColorEnum.BrightRed;
            }
            if (pct >= 25)
            {
                attr = ColorEnum.Orange;
            }
            if (pct >= 60)
            {
                attr = ColorEnum.Yellow;
            }
            if (pct >= 100)
            {
                attr = ColorEnum.BrightGreen;
            }
            if (mPtr.FearLevel != 0)
            {
                attr = ColorEnum.Purple;
                smb = "AFRAID****";
            }
            if (mPtr.SleepLevel != 0)
            {
                attr = ColorEnum.Blue;
                smb = "SLEEPING**";
            }
            if (mPtr.SmFriendly)
            {
                attr = ColorEnum.BrightBrown;
                smb = "FRIENDLY**";
            }
            int len = pct < 10 ? 1 : pct < 90 ? (pct / 10) + 1 : 10;
            SaveGame.Screen.Print(ColorEnum.White, "[----------]", RowInfo, ColInfo);
            SaveGame.Screen.Print(attr, smb.Substring(0, len), RowInfo, ColInfo + 1);
            SaveGame.Screen.Print(ColorEnum.White, mPtr.Race.SplitName1, RowInfo - 3, ColInfo);
            SaveGame.Screen.Print(ColorEnum.White, mPtr.Race.SplitName2, RowInfo - 2, ColInfo);
            SaveGame.Screen.Print(ColorEnum.White, mPtr.Race.SplitName3, RowInfo - 1, ColInfo);
        }
    }
}