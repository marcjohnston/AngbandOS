// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateLightFlaggedAction : FlaggedAction
{
    private UpdateLightFlaggedAction(Game game) : base(game) { }
    private void CaveLightHack(int y, int x)
    {
        Game.Map.Grid[y][x].PlayerLit = true;
        Game.Light.Add(new GridCoordinate(x, y));
    }

    protected override void Execute()
    {
        if (Game.LightLevel <= 0)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(RemoveLightFlaggedAction)).Check(true);
            Game.MainForm.RefreshMapLocation(Game.MapY.IntValue, Game.MapX.IntValue);
            return;
        }
        foreach (GridCoordinate gridCoordinate in Game.Light)
        {
            Game.Map.Grid[gridCoordinate.Y][gridCoordinate.X].PlayerLit = false;
            Game.Map.Grid[gridCoordinate.Y][gridCoordinate.X].TempFlag = true;
            Game.TempY[Game.TempN] = gridCoordinate.Y;
            Game.TempX[Game.TempN] = gridCoordinate.X;
            Game.TempN++;
        }
        Game.Light.Clear();
        CaveLightHack(Game.MapY.IntValue, Game.MapX.IntValue);
        if (Game.LightLevel >= 1)
        {
            CaveLightHack(Game.MapY.IntValue + 1, Game.MapX.IntValue);
            CaveLightHack(Game.MapY.IntValue - 1, Game.MapX.IntValue);
            CaveLightHack(Game.MapY.IntValue, Game.MapX.IntValue + 1);
            CaveLightHack(Game.MapY.IntValue, Game.MapX.IntValue - 1);
            CaveLightHack(Game.MapY.IntValue + 1, Game.MapX.IntValue + 1);
            CaveLightHack(Game.MapY.IntValue + 1, Game.MapX.IntValue - 1);
            CaveLightHack(Game.MapY.IntValue - 1, Game.MapX.IntValue + 1);
            CaveLightHack(Game.MapY.IntValue - 1, Game.MapX.IntValue - 1);
        }
        if (Game.LightLevel >= 2)
        {
            if (Game.GridPassable(Game.MapY.IntValue + 1, Game.MapX.IntValue))
            {
                CaveLightHack(Game.MapY.IntValue + 2, Game.MapX.IntValue);
                CaveLightHack(Game.MapY.IntValue + 2, Game.MapX.IntValue + 1);
                CaveLightHack(Game.MapY.IntValue + 2, Game.MapX.IntValue - 1);
            }
            if (Game.GridPassable(Game.MapY.IntValue - 1, Game.MapX.IntValue))
            {
                CaveLightHack(Game.MapY.IntValue - 2, Game.MapX.IntValue);
                CaveLightHack(Game.MapY.IntValue - 2, Game.MapX.IntValue + 1);
                CaveLightHack(Game.MapY.IntValue - 2, Game.MapX.IntValue - 1);
            }
            if (Game.GridPassable(Game.MapY.IntValue, Game.MapX.IntValue + 1))
            {
                CaveLightHack(Game.MapY.IntValue, Game.MapX.IntValue + 2);
                CaveLightHack(Game.MapY.IntValue + 1, Game.MapX.IntValue + 2);
                CaveLightHack(Game.MapY.IntValue - 1, Game.MapX.IntValue + 2);
            }
            if (Game.GridPassable(Game.MapY.IntValue, Game.MapX.IntValue - 1))
            {
                CaveLightHack(Game.MapY.IntValue, Game.MapX.IntValue - 2);
                CaveLightHack(Game.MapY.IntValue + 1, Game.MapX.IntValue - 2);
                CaveLightHack(Game.MapY.IntValue - 1, Game.MapX.IntValue - 2);
            }
        }
        if (Game.LightLevel >= 3)
        {
            int p = Game.LightLevel;
            if (p > 5)
            {
                p = 5;
            }
            if (Game.GridPassable(Game.MapY.IntValue + 1, Game.MapX.IntValue + 1))
            {
                CaveLightHack(Game.MapY.IntValue + 2, Game.MapX.IntValue + 2);
            }
            if (Game.GridPassable(Game.MapY.IntValue + 1, Game.MapX.IntValue - 1))
            {
                CaveLightHack(Game.MapY.IntValue + 2, Game.MapX.IntValue - 2);
            }
            if (Game.GridPassable(Game.MapY.IntValue - 1, Game.MapX.IntValue + 1))
            {
                CaveLightHack(Game.MapY.IntValue - 2, Game.MapX.IntValue + 2);
            }
            if (Game.GridPassable(Game.MapY.IntValue - 1, Game.MapX.IntValue - 1))
            {
                CaveLightHack(Game.MapY.IntValue - 2, Game.MapX.IntValue - 2);
            }
            int minY = Game.MapY.IntValue - p;
            if (minY < 0)
            {
                minY = 0;
            }
            int maxY = Game.MapY.IntValue + p;
            if (maxY > Game.CurHgt - 1)
            {
                maxY = Game.CurHgt - 1;
            }
            int minX = Game.MapX.IntValue - p;
            if (minX < 0)
            {
                minX = 0;
            }
            int maxX = Game.MapX.IntValue + p;
            if (maxX > Game.CurWid - 1)
            {
                maxX = Game.CurWid - 1;
            }
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    int dy = Game.MapY.IntValue > y ? Game.MapY.IntValue - y : y - Game.MapY.IntValue;
                    int dx = Game.MapX.IntValue > x ? Game.MapX.IntValue - x : x - Game.MapX.IntValue;
                    if (dy <= 2 && dx <= 2)
                    {
                        continue;
                    }
                    int d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
                    if (d > p)
                    {
                        continue;
                    }
                    if (Game.PlayerHasLosBold(y, x))
                    {
                        CaveLightHack(y, x);
                    }
                }
            }
        }
        foreach (GridCoordinate gridCoordinate in Game.Light)
        {
            if (Game.Map.Grid[gridCoordinate.Y][gridCoordinate.X].TempFlag)
            {
                continue;
            }
            Game.NoteSpot(gridCoordinate.Y, gridCoordinate.X);
            Game.MainForm.RefreshMapLocation(gridCoordinate.Y, gridCoordinate.X);
        }
        for (int i = 0; i < Game.TempN; i++)
        {
            int y = Game.TempY[i];
            int x = Game.TempX[i];
            Game.Map.Grid[y][x].TempFlag = false;
            if (Game.Map.Grid[y][x].PlayerLit)
            {
                continue;
            }
            Game.MainForm.RefreshMapLocation(y, x);
        }
        Game.TempN = 0;
    }
}
