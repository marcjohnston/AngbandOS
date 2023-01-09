namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrTitleRedrawAction : RedrawAction
    {
        public PrTitleRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void RedrawNow()
        {
            SaveGame.PrtTitle();
        }
    }
}
