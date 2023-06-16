namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RemoveViewFlaggedAction : FlaggedAction
{
    public RemoveViewFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        foreach (GridCoordinate gridCoordinate in SaveGame.Level.View)
        {
            GridTile cPtr = SaveGame.Level.Grid[gridCoordinate.Y][gridCoordinate.X];
            cPtr.TileFlags.Clear(GridTile.IsVisible);
            SaveGame.Level.RedrawSingleLocation(gridCoordinate.Y, gridCoordinate.X);
        }
        SaveGame.Level.View.Clear();
    }
}
