namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateRemoveLightFlaggedAction : FlaggedAction
    {
        public UpdateRemoveLightFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            if (SaveGame.Level._lightN == 0)
            {
                return;
            }
            for (int i = 0; i < SaveGame.Level._lightN; i++)
            {
                int y = SaveGame.Level._lightY[i];
                int x = SaveGame.Level._lightX[i];
                SaveGame.Level.Grid[y][x].TileFlags.Clear(GridTile.PlayerLit);
                SaveGame.Level.RedrawSingleLocation(y, x);
            }
            SaveGame.Level._lightN = 0;
        }
    }
}
