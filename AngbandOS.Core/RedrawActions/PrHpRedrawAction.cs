namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrHpRedrawAction : RedrawAction
    {
        public PrHpRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void RedrawNow()
        {
            SaveGame.PrtHp();
        }
    }
}
