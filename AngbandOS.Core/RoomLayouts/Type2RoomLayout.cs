// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.RoomLayouts;

[Serializable]
internal class Type2RoomLayout : RoomLayout
{
    private Type2RoomLayout(Game game) : base(game) { }
    public override int Type => 2;
    public override int Dy1 => 0;
    public override int Dy2 => 0;
    public override int Dx1 => -1;
    public override int Dx2 => 1;
    public override int Level => 1;
    public override void Build(int objectLevel, int yval, int xval)
    {
        int y, x;
        GridTile cPtr;
        bool light = Game.Difficulty <= Game.DieRoll(25);
        int y1A = yval - Game.DieRoll(4);
        int y2A = yval + Game.DieRoll(3);
        int x1A = xval - Game.DieRoll(11);
        int x2A = xval + Game.DieRoll(10);
        int y1B = yval - Game.DieRoll(3);
        int y2B = yval + Game.DieRoll(4);
        int x1B = xval - Game.DieRoll(10);
        int x2B = xval + Game.DieRoll(11);
        for (y = y1A - 1; y <= y2A + 1; y++)
        {
            for (x = x1A - 1; x <= x2A + 1; x++)
            {
                cPtr = Game.Map.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.InRoom = true;
                if (light)
                {
                    cPtr.SelfLit = true;
                }
            }
        }
        for (y = y1B - 1; y <= y2B + 1; y++)
        {
            for (x = x1B - 1; x <= x2B + 1; x++)
            {
                cPtr = Game.Map.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.InRoom = true;
                if (light)
                {
                    cPtr.SelfLit = true;
                }
            }
        }
        Tile wallOuter = Game.SingletonRepository.Get<Tile>(nameof(WallOuterTile));
        for (y = y1A - 1; y <= y2A + 1; y++)
        {
            cPtr = Game.Map.Grid[y][x1A - 1];
            cPtr.SetFeature(wallOuter);
            cPtr = Game.Map.Grid[y][x2A + 1];
            cPtr.SetFeature(wallOuter);
        }
        for (x = x1A - 1; x <= x2A + 1; x++)
        {
            cPtr = Game.Map.Grid[y1A - 1][x];
            cPtr.SetFeature(wallOuter);
            cPtr = Game.Map.Grid[y2A + 1][x];
            cPtr.SetFeature(wallOuter);
        }
        for (y = y1B - 1; y <= y2B + 1; y++)
        {
            cPtr = Game.Map.Grid[y][x1B - 1];
            cPtr.SetFeature(wallOuter);
            cPtr = Game.Map.Grid[y][x2B + 1];
            cPtr.SetFeature(wallOuter);
        }
        for (x = x1B - 1; x <= x2B + 1; x++)
        {
            cPtr = Game.Map.Grid[y1B - 1][x];
            cPtr.SetFeature(wallOuter);
            cPtr = Game.Map.Grid[y2B + 1][x];
            cPtr.SetFeature(wallOuter);
        }
        for (y = y1A; y <= y2A; y++)
        {
            for (x = x1A; x <= x2A; x++)
            {
                cPtr = Game.Map.Grid[y][x];
                cPtr.RevertToBackground();
            }
        }
        for (y = y1B; y <= y2B; y++)
        {
            for (x = x1B; x <= x2B; x++)
            {
                cPtr = Game.Map.Grid[y][x];
                cPtr.RevertToBackground();
            }
        }
    }

}
