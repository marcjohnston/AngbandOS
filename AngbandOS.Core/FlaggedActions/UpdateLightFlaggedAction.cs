
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateLightFlaggedAction : FlaggedAction
    {
        public UpdateLightFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        private void CaveLightHack(int y, int x)
        {
            SaveGame.Level.Grid[y][x].TileFlags.Set(GridTile.PlayerLit);
            SaveGame.Level._lightY[SaveGame.Level._lightN] = y;
            SaveGame.Level._lightX[SaveGame.Level._lightN] = x;
            SaveGame.Level._lightN++;
        }

        protected override void Execute()
        {
            int i, x, y;
            if (SaveGame.Player.LightLevel <= 0)
            {
                SaveGame.Level.ForgetLight();
                SaveGame.Level.RedrawSingleLocation(SaveGame.Player.MapY, SaveGame.Player.MapX);
                return;
            }
            for (i = 0; i < SaveGame.Level._lightN; i++)
            {
                y = SaveGame.Level._lightY[i];
                x = SaveGame.Level._lightX[i];
                SaveGame.Level.Grid[y][x].TileFlags.Clear(GridTile.PlayerLit);
                SaveGame.Level.Grid[y][x].TileFlags.Set(GridTile.TempFlag);
                SaveGame.Level.TempY[SaveGame.Level.TempN] = y;
                SaveGame.Level.TempX[SaveGame.Level.TempN] = x;
                SaveGame.Level.TempN++;
            }
            SaveGame.Level._lightN = 0;
            CaveLightHack(SaveGame.Player.MapY, SaveGame.Player.MapX);
            if (SaveGame.Player.LightLevel >= 1)
            {
                CaveLightHack(SaveGame.Player.MapY + 1, SaveGame.Player.MapX);
                CaveLightHack(SaveGame.Player.MapY - 1, SaveGame.Player.MapX);
                CaveLightHack(SaveGame.Player.MapY, SaveGame.Player.MapX + 1);
                CaveLightHack(SaveGame.Player.MapY, SaveGame.Player.MapX - 1);
                CaveLightHack(SaveGame.Player.MapY + 1, SaveGame.Player.MapX + 1);
                CaveLightHack(SaveGame.Player.MapY + 1, SaveGame.Player.MapX - 1);
                CaveLightHack(SaveGame.Player.MapY - 1, SaveGame.Player.MapX + 1);
                CaveLightHack(SaveGame.Player.MapY - 1, SaveGame.Player.MapX - 1);
            }
            if (SaveGame.Player.LightLevel >= 2)
            {
                if (SaveGame.Level.GridPassable(SaveGame.Player.MapY + 1, SaveGame.Player.MapX))
                {
                    CaveLightHack(SaveGame.Player.MapY + 2, SaveGame.Player.MapX);
                    CaveLightHack(SaveGame.Player.MapY + 2, SaveGame.Player.MapX + 1);
                    CaveLightHack(SaveGame.Player.MapY + 2, SaveGame.Player.MapX - 1);
                }
                if (SaveGame.Level.GridPassable(SaveGame.Player.MapY - 1, SaveGame.Player.MapX))
                {
                    CaveLightHack(SaveGame.Player.MapY - 2, SaveGame.Player.MapX);
                    CaveLightHack(SaveGame.Player.MapY - 2, SaveGame.Player.MapX + 1);
                    CaveLightHack(SaveGame.Player.MapY - 2, SaveGame.Player.MapX - 1);
                }
                if (SaveGame.Level.GridPassable(SaveGame.Player.MapY, SaveGame.Player.MapX + 1))
                {
                    CaveLightHack(SaveGame.Player.MapY, SaveGame.Player.MapX + 2);
                    CaveLightHack(SaveGame.Player.MapY + 1, SaveGame.Player.MapX + 2);
                    CaveLightHack(SaveGame.Player.MapY - 1, SaveGame.Player.MapX + 2);
                }
                if (SaveGame.Level.GridPassable(SaveGame.Player.MapY, SaveGame.Player.MapX - 1))
                {
                    CaveLightHack(SaveGame.Player.MapY, SaveGame.Player.MapX - 2);
                    CaveLightHack(SaveGame.Player.MapY + 1, SaveGame.Player.MapX - 2);
                    CaveLightHack(SaveGame.Player.MapY - 1, SaveGame.Player.MapX - 2);
                }
            }
            if (SaveGame.Player.LightLevel >= 3)
            {
                int p = SaveGame.Player.LightLevel;
                if (p > 5)
                {
                    p = 5;
                }
                if (SaveGame.Level.GridPassable(SaveGame.Player.MapY + 1, SaveGame.Player.MapX + 1))
                {
                    CaveLightHack(SaveGame.Player.MapY + 2, SaveGame.Player.MapX + 2);
                }
                if (SaveGame.Level.GridPassable(SaveGame.Player.MapY + 1, SaveGame.Player.MapX - 1))
                {
                    CaveLightHack(SaveGame.Player.MapY + 2, SaveGame.Player.MapX - 2);
                }
                if (SaveGame.Level.GridPassable(SaveGame.Player.MapY - 1, SaveGame.Player.MapX + 1))
                {
                    CaveLightHack(SaveGame.Player.MapY - 2, SaveGame.Player.MapX + 2);
                }
                if (SaveGame.Level.GridPassable(SaveGame.Player.MapY - 1, SaveGame.Player.MapX - 1))
                {
                    CaveLightHack(SaveGame.Player.MapY - 2, SaveGame.Player.MapX - 2);
                }
                int minY = SaveGame.Player.MapY - p;
                if (minY < 0)
                {
                    minY = 0;
                }
                int maxY = SaveGame.Player.MapY + p;
                if (maxY > SaveGame.Level.CurHgt - 1)
                {
                    maxY = SaveGame.Level.CurHgt - 1;
                }
                int minX = SaveGame.Player.MapX - p;
                if (minX < 0)
                {
                    minX = 0;
                }
                int maxX = SaveGame.Player.MapX + p;
                if (maxX > SaveGame.Level.CurWid - 1)
                {
                    maxX = SaveGame.Level.CurWid - 1;
                }
                for (y = minY; y <= maxY; y++)
                {
                    for (x = minX; x <= maxX; x++)
                    {
                        int dy = SaveGame.Player.MapY > y ? SaveGame.Player.MapY - y : y - SaveGame.Player.MapY;
                        int dx = SaveGame.Player.MapX > x ? SaveGame.Player.MapX - x : x - SaveGame.Player.MapX;
                        if (dy <= 2 && dx <= 2)
                        {
                            continue;
                        }
                        int d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
                        if (d > p)
                        {
                            continue;
                        }
                        if (SaveGame.Level.PlayerHasLosBold(y, x))
                        {
                            CaveLightHack(y, x);
                        }
                    }
                }
            }
            for (i = 0; i < SaveGame.Level._lightN; i++)
            {
                y = SaveGame.Level._lightY[i];
                x = SaveGame.Level._lightX[i];
                if (SaveGame.Level.Grid[y][x].TileFlags.IsSet(GridTile.TempFlag))
                {
                    continue;
                }
                SaveGame.Level.NoteSpot(y, x);
                SaveGame.Level.RedrawSingleLocation(y, x);
            }
            for (i = 0; i < SaveGame.Level.TempN; i++)
            {
                y = SaveGame.Level.TempY[i];
                x = SaveGame.Level.TempX[i];
                SaveGame.Level.Grid[y][x].TileFlags.Clear(GridTile.TempFlag);
                if (SaveGame.Level.Grid[y][x].TileFlags.IsSet(GridTile.PlayerLit))
                {
                    continue;
                }
                SaveGame.Level.RedrawSingleLocation(y, x);
            }
            SaveGame.Level.TempN = 0;
        }
    }
}
