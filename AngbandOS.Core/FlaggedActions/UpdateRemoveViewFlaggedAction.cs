namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateRemoveViewFlaggedAction : FlaggedAction
    {
        public UpdateRemoveViewFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            if (SaveGame.Level._viewN == 0)
            {
                return;
            }
            for (int i = 0; i < SaveGame.Level._viewN; i++)
            {
                int y = SaveGame.Level._viewY[i];
                int x = SaveGame.Level._viewX[i];
                GridTile cPtr = SaveGame.Level.Grid[y][x];
                cPtr.TileFlags.Clear(GridTile.IsVisible);
                SaveGame.Level.RedrawSingleLocation(y, x);
            }
            SaveGame.Level._viewN = 0;
        }
    }
}
