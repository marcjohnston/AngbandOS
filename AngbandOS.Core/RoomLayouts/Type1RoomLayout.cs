﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal class Type1RoomLayout : RoomLayout
{
    private Type1RoomLayout(SaveGame saveGame) : base(saveGame) { }
    public override int Type => 1;
    public override void Build(int yval, int xval)
    {
        int y, x;
        GridTile cPtr;
        bool light = SaveGame.Difficulty <= SaveGame.Rng.DieRoll(25);
        int y1 = yval - SaveGame.Rng.DieRoll(4);
        int y2 = yval + SaveGame.Rng.DieRoll(3);
        int x1 = xval - SaveGame.Rng.DieRoll(11);
        int x2 = xval + SaveGame.Rng.DieRoll(11);
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = SaveGame.Grid[y][x];
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
            cPtr = SaveGame.Grid[y][x1 - 1];
            cPtr.SetFeature("WallOuter");
            cPtr = SaveGame.Grid[y][x2 + 1];
            cPtr.SetFeature("WallOuter");
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = SaveGame.Grid[y1 - 1][x];
            cPtr.SetFeature("WallOuter");
            cPtr = SaveGame.Grid[y2 + 1][x];
            cPtr.SetFeature("WallOuter");
        }
        if (SaveGame.Rng.RandomLessThan(20) == 0)
        {
            for (y = y1; y <= y2; y += 2)
            {
                for (x = x1; x <= x2; x += 2)
                {
                    cPtr = SaveGame.Grid[y][x];
                    cPtr.SetFeature("Pillar");
                }
            }
        }
        else if (SaveGame.Rng.RandomLessThan(50) == 0)
        {
            for (y = y1 + 2; y <= y2 - 2; y += 2)
            {
                cPtr = SaveGame.Grid[y][x1];
                cPtr.SetFeature("Pillar");
                cPtr = SaveGame.Grid[y][x2];
                cPtr.SetFeature("Pillar");
            }
            for (x = x1 + 2; x <= x2 - 2; x += 2)
            {
                cPtr = SaveGame.Grid[y1][x];
                cPtr.SetFeature("Pillar");
                cPtr = SaveGame.Grid[y2][x];
                cPtr.SetFeature("Pillar");
            }
        }
    }
}