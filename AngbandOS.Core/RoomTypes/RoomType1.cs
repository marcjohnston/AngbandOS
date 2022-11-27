namespace AngbandOS.Core.RoomTypes
{
    internal class RoomType1 : RoomType
    {
        public override int Type => 1;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
            int y, x;
            GridTile cPtr;
            bool light = saveGame.Difficulty <= Program.Rng.DieRoll(25);
            int y1 = yval - Program.Rng.DieRoll(4);
            int y2 = yval + Program.Rng.DieRoll(3);
            int x1 = xval - Program.Rng.DieRoll(11);
            int x2 = xval + Program.Rng.DieRoll(11);
            for (y = y1 - 1; y <= y2 + 1; y++)
            {
                for (x = x1 - 1; x <= x2 + 1; x++)
                {
                    cPtr = saveGame.Level.Grid[y][x];
                    cPtr.RevertToBackground();
                    cPtr.TileFlags.Set(GridTile.InRoom);
                    if (light)
                    {
                        cPtr.TileFlags.Set(GridTile.SelfLit);
                    }
                }
            }
            for (y = y1 - 1; y <= y2 + 1; y++)
            {
                cPtr = saveGame.Level.Grid[y][x1 - 1];
                cPtr.SetFeature("WallOuter");
                cPtr = saveGame.Level.Grid[y][x2 + 1];
                cPtr.SetFeature("WallOuter");
            }
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = saveGame.Level.Grid[y1 - 1][x];
                cPtr.SetFeature("WallOuter");
                cPtr = saveGame.Level.Grid[y2 + 1][x];
                cPtr.SetFeature("WallOuter");
            }
            if (Program.Rng.RandomLessThan(20) == 0)
            {
                for (y = y1; y <= y2; y += 2)
                {
                    for (x = x1; x <= x2; x += 2)
                    {
                        cPtr = saveGame.Level.Grid[y][x];
                        cPtr.SetFeature("Pillar");
                    }
                }
            }
            else if (Program.Rng.RandomLessThan(50) == 0)
            {
                for (y = y1 + 2; y <= y2 - 2; y += 2)
                {
                    cPtr = saveGame.Level.Grid[y][x1];
                    cPtr.SetFeature("Pillar");
                    cPtr = saveGame.Level.Grid[y][x2];
                    cPtr.SetFeature("Pillar");
                }
                for (x = x1 + 2; x <= x2 - 2; x += 2)
                {
                    cPtr = saveGame.Level.Grid[y1][x];
                    cPtr.SetFeature("Pillar");
                    cPtr = saveGame.Level.Grid[y2][x];
                    cPtr.SetFeature("Pillar");
                }
            }
        }
    }
}
