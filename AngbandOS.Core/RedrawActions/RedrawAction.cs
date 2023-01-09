
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal abstract class RedrawAction
    {
        protected SaveGame SaveGame { get; }
        private bool _flag;
        public virtual void Set()
        {
            _flag = true;
        }
        public virtual void Clear()
        {
            _flag = false;
        }
        public virtual bool IsSet => _flag;
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
