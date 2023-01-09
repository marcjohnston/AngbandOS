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
        public void Redraw(bool force = false)
        {
            if (IsSet || force)
            {
                Clear();
                Draw();
            }
        }
        protected abstract void Draw();
        public RedrawAction(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
    }
}
