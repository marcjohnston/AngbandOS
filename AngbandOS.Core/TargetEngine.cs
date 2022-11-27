// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Commands;
using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

using System.Collections.Generic;

namespace AngbandOS
{
    internal class TargetEngine
    {
        private readonly SaveGame SaveGame;

        public TargetEngine(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        public bool GetDirectionNoAim(out int dp)
        {
            dp = 0;
            int dir = SaveGame.CommandDirection;
            while (dir == 0)
            {
                if (!SaveGame.GetCom("Direction (Escape to cancel)? ", out char ch))
                {
                    break;
                }
                dir = SaveGame.GetKeymapDir(ch);
            }
            if (dir == 5)
            {
                dir = 0;
            }
            if (dir == 0)
            {
                return false;
            }
            SaveGame.CommandDirection = dir;
            if (SaveGame.Player.TimedConfusion != 0)
            {
                if (Program.Rng.RandomLessThan(100) < 75)
                {
                    dir = SaveGame.Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
                }
            }
            if (SaveGame.CommandDirection != dir)
            {
                SaveGame.MsgPrint("You are confused.");
            }
            dp = dir;
            return true;
        }

        public void GetDirectionNoAutoAim(out int dp)
        {
            dp = 0;
            int dir = 0;
            while (dir == 0)
            {
                string p = !TargetOkay()
                    ? "Direction ('*' to choose a target, Escape to cancel)? "
                    : "Direction ('5' for target, '*' to re-target, Escape to cancel)? ";
                if (!SaveGame.GetCom(p, out char command))
                {
                    break;
                }
                switch (command)
                {
                    case 'T':
                    case 't':
                    case '.':
                    case '5':
                    case '0':
                        {
                            dir = 5;
                            break;
                        }
                    case '*':
                        {
                            if (TargetSet(Constants.TargetKill))
                            {
                                dir = 5;
                            }
                            break;
                        }
                    default:
                        {
                            dir = SaveGame.GetKeymapDir(command);
                            break;
                        }
                }
                if (dir == 5 && !TargetOkay())
                {
                    dir = 0;
                }
            }
            if (dir == 0)
            {
                return;
            }
            SaveGame.CommandDirection = dir;
            if (SaveGame.Player.TimedConfusion != 0)
            {
                dir = SaveGame.Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
            }
            if (SaveGame.CommandDirection != dir)
            {
                SaveGame.MsgPrint("You are confused.");
            }
            dp = dir;
        }

        public bool GetDirectionWithAim(out int dp)
        {
            dp = 0;
            int dir = SaveGame.CommandDirection;
            if (TargetOkay())
            {
                dir = 5;
            }
            while (dir == 0)
            {
                string p = !TargetOkay()
                    ? "Direction ('*' to choose a target, Escape to cancel)? "
                    : "Direction ('5' for target, '*' to re-target, Escape to cancel)? ";
                if (!SaveGame.GetCom(p, out char command))
                {
                    break;
                }
                switch (command)
                {
                    case 'T':
                    case 't':
                    case '.':
                    case '5':
                    case '0':
                        {
                            dir = 5;
                            break;
                        }
                    case '*':
                        {
                            if (TargetSet(Constants.TargetKill))
                            {
                                dir = 5;
                            }
                            break;
                        }
                    default:
                        {
                            dir = SaveGame.GetKeymapDir(command);
                            break;
                        }
                }
                if (dir == 5 && !TargetOkay())
                {
                    dir = 0;
                }
            }
            if (dir == 0)
            {
                return false;
            }
            SaveGame.CommandDirection = dir;
            if (SaveGame.Player.TimedConfusion != 0)
            {
                dir = SaveGame.Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
            }
            if (SaveGame.CommandDirection != dir)
            {
                SaveGame.MsgPrint("You are confused.");
            }
            dp = dir;
            return true;
        }

        public void PanelBoundsCenter()
        {
            SaveGame.Level.PanelRow = SaveGame.Level.PanelRowMin / (Constants.ScreenHgt / 2);
            SaveGame.Level.PanelRowMax = SaveGame.Level.PanelRowMin + Constants.ScreenHgt - 1;
            SaveGame.Level.PanelRowPrt = SaveGame.Level.PanelRowMin - 1;
            SaveGame.Level.PanelCol = SaveGame.Level.PanelColMin / (Constants.ScreenWid / 2);
            SaveGame.Level.PanelColMax = SaveGame.Level.PanelColMin + Constants.ScreenWid - 1;
            SaveGame.Level.PanelColPrt = SaveGame.Level.PanelColMin - 13;
        }

        public void RecenterScreenAroundPlayer()
        {
            int y = SaveGame.Player.MapY;
            int x = SaveGame.Player.MapX;
            int maxProwMin = SaveGame.Level.MaxPanelRows * (Constants.ScreenHgt / 2);
            int maxPcolMin = SaveGame.Level.MaxPanelCols * (Constants.ScreenWid / 2);
            int prowMin = y - (Constants.ScreenHgt / 2);
            if (prowMin > maxProwMin)
            {
                prowMin = maxProwMin;
            }
            else if (prowMin < 0)
            {
                prowMin = 0;
            }
            int pcolMin = x - (Constants.ScreenWid / 2);
            if (pcolMin > maxPcolMin)
            {
                pcolMin = maxPcolMin;
            }
            else if (pcolMin < 0)
            {
                pcolMin = 0;
            }
            if (prowMin == SaveGame.Level.PanelRowMin && pcolMin == SaveGame.Level.PanelColMin)
            {
                return;
            }
            SaveGame.Level.PanelRowMin = prowMin;
            SaveGame.Level.PanelColMin = pcolMin;
            PanelBoundsCenter();
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMap);
        }

        public bool TargetOkay()
        {
            if (SaveGame.TargetWho < 0)
            {
                return true;
            }
            if (SaveGame.TargetWho <= 0)
            {
                return false;
            }
            if (!TargetAble(SaveGame.TargetWho))
            {
                return false;
            }
            Monster mPtr = SaveGame.Level.Monsters[SaveGame.TargetWho];
            SaveGame.TargetRow = mPtr.MapY;
            SaveGame.TargetCol = mPtr.MapX;
            return true;
        }

        public bool TargetSet(int mode)
        {
            int y = SaveGame.Player.MapY;
            int x = SaveGame.Player.MapX;
            bool done = false;
            SaveGame.TargetWho = 0;
            TargetSetPrepare(mode);
            int m = 0;
            if (SaveGame.Level.TempN != 0)
            {
                y = SaveGame.Level.TempY[m];
                x = SaveGame.Level.TempX[m];
            }
            while (!done)
            {
                GridTile cPtr = SaveGame.Level.Grid[y][x];
                string info = TargetAble(cPtr.MonsterIndex) ? "t,T,*" : "T,*";
                char query = TargetSetAux(y, x, mode | Constants.TargetLook, info);
                switch (query)
                {
                    case '\x1b':
                        {
                            done = true;
                            break;
                        }
                    case 't':
                        {
                            if (TargetAble(cPtr.MonsterIndex))
                            {
                                SaveGame.HealthTrack(cPtr.MonsterIndex);
                                SaveGame.TargetWho = cPtr.MonsterIndex;
                                SaveGame.TargetRow = y;
                                SaveGame.TargetCol = x;
                                done = true;
                            }
                            break;
                        }
                    case 'T':
                        SaveGame.TargetWho = -1;
                        SaveGame.TargetRow = y;
                        SaveGame.TargetCol = x;
                        done = true;
                        break;

                    case '*':
                        {
                            if (x == SaveGame.Level.TempX[m] && y == SaveGame.Level.TempY[m])
                            {
                                if (++m >= SaveGame.Level.TempN)
                                {
                                    m = 0;
                                    done = true;
                                }
                                else
                                {
                                    y = SaveGame.Level.TempY[m];
                                    x = SaveGame.Level.TempX[m];
                                }
                            }
                            else
                            {
                                y = SaveGame.Level.TempY[m];
                                x = SaveGame.Level.TempX[m];
                            }
                            break;
                        }
                    default:
                        {
                            int d = SaveGame.GetKeymapDir(query);
                            if (d != 0)
                            {
                                x += SaveGame.Level.KeypadDirectionXOffset[d];
                                y += SaveGame.Level.KeypadDirectionYOffset[d];
                                if (x >= SaveGame.Level.CurWid - 1 || x > SaveGame.Level.PanelColMax)
                                {
                                    x--;
                                }
                                else if (x <= 0 || x < SaveGame.Level.PanelColMin)
                                {
                                    x++;
                                }
                                if (y >= SaveGame.Level.CurHgt - 1 || y > SaveGame.Level.PanelRowMax)
                                {
                                    y--;
                                }
                                else if (y <= 0 || y < SaveGame.Level.PanelRowMin)
                                {
                                    y++;
                                }
                            }
                            break;
                        }
                }
            }
            SaveGame.Level.TempN = 0;
            SaveGame.PrintLine("", 0, 0);
            return SaveGame.TargetWho != 0;
        }

        public bool TgtPt(out int x, out int y)
        {
            char ch = '\0';
            bool success = false;
            x = SaveGame.Player.MapX;
            y = SaveGame.Player.MapY;
            bool cv = SaveGame.CursorVisible;
            SaveGame.CursorVisible = true;
            SaveGame.MsgPrint("Select a point and press space.");
            while (ch != 27 && ch != ' ' && !SaveGame.Shutdown)
            {
                SaveGame.Level.MoveCursorRelative(y, x);
                ch = SaveGame.Inkey();
                switch (ch)
                {
                    case '\x1b':
                        break;

                    case ' ':
                        success = true;
                        break;

                    default:
                        {
                            int d = SaveGame.GetKeymapDir(ch);
                            if (d == 0)
                            {
                                break;
                            }
                            x += SaveGame.Level.KeypadDirectionXOffset[d];
                            y += SaveGame.Level.KeypadDirectionYOffset[d];
                            if (x >= SaveGame.Level.CurWid - 1 || x >= SaveGame.Level.PanelColMin + Constants.ScreenWid)
                            {
                                x--;
                            }
                            else if (x <= 0 || x <= SaveGame.Level.PanelColMin)
                            {
                                x++;
                            }
                            if (y >= SaveGame.Level.CurHgt - 1 || y >= SaveGame.Level.PanelRowMin + Constants.ScreenHgt)
                            {
                                y--;
                            }
                            else if (y <= 0 || y <= SaveGame.Level.PanelRowMin)
                            {
                                y++;
                            }
                            break;
                        }
                }
            }
            SaveGame.CursorVisible = cv;
            SaveGame.UpdateScreen();
            return success;
        }

        private string LookMonDesc(int mIdx)
        {
            Monster mPtr = SaveGame.Level.Monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            bool living = (rPtr.Flags3 & MonsterFlag3.Undead) == 0;
            if ((rPtr.Flags3 & MonsterFlag3.Demon) != 0)
            {
                living = false;
            }
            if ((rPtr.Flags3 & MonsterFlag3.Cthuloid) != 0)
            {
                living = false;
            }
            if ((rPtr.Flags3 & MonsterFlag3.Nonliving) != 0)
            {
                living = false;
            }
            if ("Egv".Contains(rPtr.Character.ToString()))
            {
                living = false;
            }
            if (mPtr.Health >= mPtr.MaxHealth)
            {
                return living ? "unhurt" : "undamaged";
            }
            int perc = 100 * mPtr.Health / mPtr.MaxHealth;
            if (perc >= 60)
            {
                return living ? "somewhat wounded" : "somewhat damaged";
            }
            if (perc >= 25)
            {
                return living ? "wounded" : "damaged";
            }
            if (perc >= 10)
            {
                return living ? "badly wounded" : "badly damaged";
            }
            return living ? "almost dead" : "almost destroyed";
        }

        private bool TargetAble(int mIdx)
        {
            Monster mPtr = SaveGame.Level.Monsters[mIdx];
            if (mPtr.Race == null)
            {
                return false;
            }
            if (!mPtr.IsVisible)
            {
                return false;
            }
            if (!SaveGame.Level.Projectable(SaveGame.Player.MapY, SaveGame.Player.MapX, mPtr.MapY, mPtr.MapX))
            {
                return false;
            }
            if (SaveGame.Player.TimedHallucinations != 0)
            {
                return false;
            }
            return true;
        }

        private bool TargetSetAccept(int y, int x)
        {
            int nextOIdx;
            if (y == SaveGame.Player.MapY && x == SaveGame.Player.MapX)
            {
                return true;
            }
            if (SaveGame.Player.TimedHallucinations != 0)
            {
                return false;
            }
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            if (cPtr.MonsterIndex != 0)
            {
                Monster mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
                if (mPtr.IsVisible)
                {
                    return true;
                }
            }
            for (int thisOIdx = cPtr.ItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                Item oPtr = SaveGame.Level.Items[thisOIdx];
                nextOIdx = oPtr.NextInStack;
                if (oPtr.Marked)
                {
                    return true;
                }
            }
            if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised))
            {
                return cPtr.FeatureType.IsInteresting;
            }
            return false;
        }

        private char TargetSetAux(int y, int x, int mode, string info)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            char query;
            do
            {
                query = ' ';
                bool boring = true;
                string s1 = "You see ";
                string s2 = "";
                string s3 = "";
                if (y == SaveGame.Player.MapY && x == SaveGame.Player.MapX)
                {
                    s1 = "You are ";
                    s2 = "on ";
                }
                string outVal;
                if (SaveGame.Player.TimedHallucinations != 0)
                {
                    const string name = "something strange";
                    outVal = $"{s1}{s2}{s3}{name} [{info}]";
                    SaveGame.PrintLine(outVal, 0, 0);
                    SaveGame.Level.MoveCursorRelative(y, x);
                    query = SaveGame.Inkey();
                    if (!SaveGame.Shutdown)
                    {
                        break;
                    }

                    if (query != '\r' && query != '\n')
                    {
                        break;
                    }
                    continue;
                }
                int thisOIdx;
                int nextOIdx;
                if (cPtr.MonsterIndex != 0)
                {
                    Monster mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
                    MonsterRace rPtr = mPtr.Race;
                    if (mPtr.IsVisible)
                    {
                        bool recall = false;
                        boring = false;
                        string mName = mPtr.MonsterDesc(0x08);
                        SaveGame.HealthTrack(cPtr.MonsterIndex);
                        SaveGame.HandleStuff();
                        while (true && !SaveGame.Shutdown)
                        {
                            if (recall)
                            {
                                SaveGame.SaveScreen();
                                rPtr.Knowledge.Display();
                                SaveGame.Print(Colour.White, $"  [r,{info}]", -1);
                                query = SaveGame.Inkey();
                                SaveGame.Load();
                            }
                            else
                            {
                                string c = (mPtr.Mind & Constants.SmCloned) != 0 ? " (clone)" : "";
                                string a = (mPtr.Mind & Constants.SmFriendly) != 0 ? " (allied) " : " ";
                                outVal = $"{s1}{s2}{s3}{mName} ({LookMonDesc(cPtr.MonsterIndex)}){c}{a}[r,{info}]";
                                SaveGame.PrintLine(outVal, 0, 0);
                                SaveGame.Level.MoveCursorRelative(y, x);
                                query = SaveGame.Inkey();
                            }
                            if (query != 'r')
                            {
                                break;
                            }
                            recall = !recall;
                        }
                        if (query != '\r' && query != '\n' && query != ' ')
                        {
                            break;
                        }
                        if (query == ' ' && (mode & Constants.TargetLook) == 0)
                        {
                            break;
                        }
                        s1 = "It is ";
                        if ((rPtr.Flags1 & MonsterFlag1.Female) != 0)
                        {
                            s1 = "She is ";
                        }
                        else if ((rPtr.Flags1 & MonsterFlag1.Male) != 0)
                        {
                            s1 = "He is ";
                        }
                        s2 = "carrying ";
                        for (thisOIdx = mPtr.FirstHeldItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
                        {
                            Item oPtr = SaveGame.Level.Items[thisOIdx];
                            nextOIdx = oPtr.NextInStack;
                            string oName = oPtr.Description(true, 3);
                            outVal = $"{s1}{s2}{s3}{oName} [{info}]";
                            SaveGame.PrintLine(outVal, 0, 0);
                            SaveGame.Level.MoveCursorRelative(y, x);
                            query = SaveGame.Inkey();
                            if (query != '\r' && query != '\n' && query != ' ')
                            {
                                break;
                            }
                            if (query == ' ' && (mode & Constants.TargetLook) == 0)
                            {
                                break;
                            }
                            s2 = "also carrying ";
                        }
                        if (thisOIdx != 0)
                        {
                            break;
                        }
                        s2 = "on ";
                    }
                }
                for (thisOIdx = cPtr.ItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
                {
                    Item oPtr = SaveGame.Level.Items[thisOIdx];
                    nextOIdx = oPtr.NextInStack;
                    if (oPtr.Marked)
                    {
                        boring = false;
                        string oName = oPtr.Description(true, 3);
                        outVal = $"{s1}{s2}{s3}{oName} [{info}]";
                        SaveGame.PrintLine(outVal, 0, 0);
                        SaveGame.Level.MoveCursorRelative(y, x);
                        query = SaveGame.Inkey();
                        if (query != '\r' && query != '\n' && query != ' ')
                        {
                            break;
                        }
                        if (query == ' ' && (mode & Constants.TargetLook) == 0)
                        {
                            break;
                        }
                        s1 = "It is ";
                        if (oPtr.Count != 1)
                        {
                            s1 = "They are ";
                        }
                        s2 = "on ";
                    }
                }
                if (thisOIdx != 0)
                {
                    break;
                }
                string feat = string.IsNullOrEmpty(cPtr.FeatureType.AppearAs)
                    ? ObjectRepository.FloorTileTypes[cPtr.BackgroundFeature.AppearAs].Name
                    : ObjectRepository.FloorTileTypes[cPtr.FeatureType.AppearAs].Name;
                if (cPtr.TileFlags.IsClear(GridTile.PlayerMemorised) && !SaveGame.Level.PlayerCanSeeBold(y, x))
                {
                    feat = string.Empty;
                }
                if (boring || (!cPtr.FeatureType.IsOpenFloor))
                {
                    string name = "unknown grid";
                    if (feat != string.Empty)
                    {
                        name = ObjectRepository.FloorTileTypes[feat].Description;
                        if (s2 != "" && cPtr.FeatureType.BlocksLos)
                        {
                            s2 = "in ";
                        }
                    }
                    s3 = name[0].IsVowel() ? "an " : "a ";
                    if (cPtr.FeatureType.IsShop)
                    {
                        s3 = name[0].IsVowel() ? "the entrance to an " : "the entrance to a ";
                    }
                    outVal = $"{s1}{s2}{s3}{name} [{info}]";
                    SaveGame.PrintLine(outVal, 0, 0);
                    SaveGame.Level.MoveCursorRelative(y, x);
                    query = SaveGame.Inkey();
                    if (query != '\r' && query != '\n' && query != ' ')
                    {
                        break;
                    }
                }
            }
            while (query == '\r' || query == '\n');
            return query;
        }

        private void TargetSetPrepare(int mode)
        {
            int y;
            SaveGame.Level.TempN = 0;
            for (y = SaveGame.Level.PanelRowMin; y <= SaveGame.Level.PanelRowMax; y++)
            {
                int x;
                for (x = SaveGame.Level.PanelColMin; x <= SaveGame.Level.PanelColMax; x++)
                {
                    GridTile cPtr = SaveGame.Level.Grid[y][x];
                    if (!SaveGame.Level.PlayerHasLosBold(y, x))
                    {
                        continue;
                    }
                    if (!TargetSetAccept(y, x))
                    {
                        continue;
                    }
                    if ((mode & Constants.TargetKill) != 0 && !TargetAble(cPtr.MonsterIndex))
                    {
                        continue;
                    }
                    SaveGame.Level.TempX[SaveGame.Level.TempN] = x;
                    SaveGame.Level.TempY[SaveGame.Level.TempN] = y;
                    SaveGame.Level.TempN++;
                }
            }
            List<TargetLocation> list = new List<TargetLocation>();
            for (int i = 0; i < SaveGame.Level.TempN; i++)
            {
                list.Add(new TargetLocation(SaveGame.Level.TempY[i], SaveGame.Level.TempX[i],
                    SaveGame.Level.Distance(SaveGame.Level.TempY[i], SaveGame.Level.TempX[i], SaveGame.Player.MapY, SaveGame.Player.MapX)));
            }
            list.Sort();
            for (int i = 0; i < SaveGame.Level.TempN; i++)
            {
                SaveGame.Level.TempX[i] = list[i].X;
                SaveGame.Level.TempY[i] = list[i].Y;
            }
        }
    }
}