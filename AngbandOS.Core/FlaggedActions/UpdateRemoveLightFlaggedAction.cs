namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateRemoveLightFlaggedAction : FlaggedAction
    {
        public UpdateRemoveLightFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            foreach (GridCoordinate gridCoordinate in SaveGame.Level.Light)
            {
                SaveGame.Level.Grid[gridCoordinate.Y][gridCoordinate.X].TileFlags.Clear(GridTile.PlayerLit);
                SaveGame.Level.RedrawSingleLocation(gridCoordinate.Y, gridCoordinate.X);

            }
            SaveGame.Level.Light.Clear();
        }
    }
}
