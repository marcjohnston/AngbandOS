﻿namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal abstract class FlaggedAction
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
        public void Check(bool force = false)
        {
            if (IsSet || force)
            {
                Clear();
                Execute();
            }
        }
        protected abstract void Execute();
        public FlaggedAction(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
    }
}