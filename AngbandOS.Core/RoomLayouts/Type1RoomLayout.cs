// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal class Type1RoomLayout : RoomLayout
{
    private Type1RoomLayout(Game game) : base(game) { }
    public override int Type => 1;
    public override int Dy1 => 0;
    public override int Dy2 => 0;
    public override int Dx1 => -1;
    public override int Dx2 => 1;
    public override int Level => 1;
    public override void Build(int yval, int xval)
    {
        int y, x;
        GridTile cPtr;
        bool light = Game.Difficulty <= Game.DieRoll(25);
        int y1 = yval - Game.DieRoll(4);
        int y2 = yval + Game.DieRoll(3);
        int x1 = xval - Game.DieRoll(11);
        int x2 = xval + Game.DieRoll(11);
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            for (x = x1 - 1; x <= x2 + 1; x++)
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
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = Game.Map.Grid[y][x1 - 1];
            cPtr.SetFeature(wallOuter);
            cPtr = Game.Map.Grid[y][x2 + 1];
            cPtr.SetFeature(wallOuter);
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = Game.Map.Grid[y1 - 1][x];
            cPtr.SetFeature(wallOuter);
            cPtr = Game.Map.Grid[y2 + 1][x];
            cPtr.SetFeature(wallOuter);
        }
        Tile pillar = Game.SingletonRepository.Get<Tile>(nameof(PillarTile));
        if (Game.RandomLessThan(20) == 0)
        {
            for (y = y1; y <= y2; y += 2)
            {
                for (x = x1; x <= x2; x += 2)
                {
                    cPtr = Game.Map.Grid[y][x];
                    cPtr.SetFeature(pillar);
                }
            }
        }
        else if (Game.RandomLessThan(50) == 0)
        {
            for (y = y1 + 2; y <= y2 - 2; y += 2)
            {
                cPtr = Game.Map.Grid[y][x1];
                cPtr.SetFeature(pillar);
                cPtr = Game.Map.Grid[y][x2];
                cPtr.SetFeature(pillar);
            }
            for (x = x1 + 2; x <= x2 - 2; x += 2)
            {
                cPtr = Game.Map.Grid[y1][x];
                cPtr.SetFeature(pillar);
                cPtr = Game.Map.Grid[y2][x];
                cPtr.SetFeature(pillar);
            }
        }
    }
}
