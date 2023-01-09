namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrLevRedrawAction : RedrawAction
    {
        public PrLevRedrawAction(SaveGame saveGame) : base (saveGame) { }
        protected override void RedrawNow()
        {
            SaveGame.PrtLevel();
        }
    }
}
