namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal abstract class RedrawAction
    {
        protected SaveGame SaveGame { get; }
        private bool _flag;
        public void Set()
        {
            _flag = true;
        }
        public void Clear()
        {
            _flag = false;
        }
        public bool IsSet => _flag;
        public void Redraw()
        {
            if (IsSet)
            {
                Clear();
                RedrawNow();
            }
        }
        protected abstract void RedrawNow();
        public RedrawAction(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
    }
    [Serializable]
    internal class PrExpRedrawAction : RedrawAction
    {
        public PrExpRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void RedrawNow()
        {
            throw new NotImplementedException();
        }
    }
}
