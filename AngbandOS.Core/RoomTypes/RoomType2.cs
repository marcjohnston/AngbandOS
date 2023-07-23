// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

internal class RoomType2 : RoomType
{
    public override int Type => 2;
    public override void Build(SaveGame saveGame, int yval, int xval)
    {
        int y, x;
        GridTile cPtr;
        bool light = saveGame.Difficulty <= Program.Rng.DieRoll(25);
        int y1A = yval - Program.Rng.DieRoll(4);
        int y2A = yval + Program.Rng.DieRoll(3);
        int x1A = xval - Program.Rng.DieRoll(11);
        int x2A = xval + Program.Rng.DieRoll(10);
        int y1B = yval - Program.Rng.DieRoll(3);
        int y2B = yval + Program.Rng.DieRoll(4);
        int x1B = xval - Program.Rng.DieRoll(10);
        int x2B = xval + Program.Rng.DieRoll(11);
        for (y = y1A - 1; y <= y2A + 1; y++)
        {
            for (x = x1A - 1; x <= x2A + 1; x++)
            {
                cPtr = saveGame.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.TileFlags.Set(GridTile.InRoom);
                if (light)
                {
                    cPtr.TileFlags.Set(GridTile.SelfLit);
                }
            }
        }
        for (y = y1B - 1; y <= y2B + 1; y++)
        {
            for (x = x1B - 1; x <= x2B + 1; x++)
            {
                cPtr = saveGame.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.TileFlags.Set(GridTile.InRoom);
                if (light)
                {
                    cPtr.TileFlags.Set(GridTile.SelfLit);
                }
            }
        }
        for (y = y1A - 1; y <= y2A + 1; y++)
        {
            cPtr = saveGame.Grid[y][x1A - 1];
            cPtr.SetFeature("WallOuter");
            cPtr = saveGame.Grid[y][x2A + 1];
            cPtr.SetFeature("WallOuter");
        }
        for (x = x1A - 1; x <= x2A + 1; x++)
        {
            cPtr = saveGame.Grid[y1A - 1][x];
            cPtr.SetFeature("WallOuter");
            cPtr = saveGame.Grid[y2A + 1][x];
            cPtr.SetFeature("WallOuter");
        }
        for (y = y1B - 1; y <= y2B + 1; y++)
        {
            cPtr = saveGame.Grid[y][x1B - 1];
            cPtr.SetFeature("WallOuter");
            cPtr = saveGame.Grid[y][x2B + 1];
            cPtr.SetFeature("WallOuter");
        }
        for (x = x1B - 1; x <= x2B + 1; x++)
        {
            cPtr = saveGame.Grid[y1B - 1][x];
            cPtr.SetFeature("WallOuter");
            cPtr = saveGame.Grid[y2B + 1][x];
            cPtr.SetFeature("WallOuter");
        }
        for (y = y1A; y <= y2A; y++)
        {
            for (x = x1A; x <= x2A; x++)
            {
                cPtr = saveGame.Grid[y][x];
                cPtr.RevertToBackground();
            }
        }
        for (y = y1B; y <= y2B; y++)
        {
            for (x = x1B; x <= x2B; x++)
            {
                cPtr = saveGame.Grid[y][x];
                cPtr.RevertToBackground();
            }
        }
    }

}
