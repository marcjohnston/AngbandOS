
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrDTrapRedrawAction : RedrawAction
    {
        private const int ColDtrap = 53;
        private const int RowDtrap = 44;
        public PrDTrapRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            int count = 0;
            if (SaveGame.Level.Grid[SaveGame.Player.MapY][SaveGame.Player.MapX].TileFlags.IsClear(GridTile.TrapsDetected))
            {
                SaveGame.Print(Colour.Green, "     ", RowDtrap, ColDtrap);
                return;
            }
            if (SaveGame.Level.Grid[SaveGame.Player.MapY - 1][SaveGame.Player.MapX].TileFlags.IsSet(GridTile.TrapsDetected))
            {
                count++;
            }
            if (SaveGame.Level.Grid[SaveGame.Player.MapY + 1][SaveGame.Player.MapX].TileFlags.IsSet(GridTile.TrapsDetected))
            {
                count++;
            }
            if (SaveGame.Level.Grid[SaveGame.Player.MapY][SaveGame.Player.MapX - 1].TileFlags.IsSet(GridTile.TrapsDetected))
            {
                count++;
            }
            if (SaveGame.Level.Grid[SaveGame.Player.MapY][SaveGame.Player.MapX + 1].TileFlags.IsSet(GridTile.TrapsDetected))
            {
                count++;
            }
            if (count == 4)
            {
                SaveGame.Print(Colour.Green, "DTrap", RowDtrap, ColDtrap);
            }
            else
            {
                SaveGame.Print(Colour.Yellow, "DTRAP", RowDtrap, ColDtrap);
            }
        }
    }
}
