
namespace AngbandOS.Core.FlaggedActions
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

    [Serializable]
    internal class UpdateBonusesFlaggedAction : FlaggedAction
    {
        public UpdateBonusesFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
    [Serializable]
    internal class UpdateDistancesFlaggedAction : FlaggedAction
    {
        public UpdateDistancesFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
    [Serializable]
    internal class UpdateHealthFlaggedAction : FlaggedAction
    {
        public UpdateHealthFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
    [Serializable]
    internal class UpdateLightFlaggedAction : FlaggedAction
    {
        public UpdateLightFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
    [Serializable]
    internal class UpdateManaFlaggedAction : FlaggedAction
    {
        public UpdateManaFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }

    }
    [Serializable]
    internal class UpdateMonstersFlaggedAction : FlaggedAction
    {
        public UpdateMonstersFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
    [Serializable]
    internal class UpdateRemoveLightFlaggedAction : FlaggedAction
    {
        public UpdateRemoveLightFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
    [Serializable]
    internal class UpdateRemoveViewFlaggedAction : FlaggedAction
    {
        public UpdateRemoveViewFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }

    }
    [Serializable]
    internal class UpdateScentFlaggedAction : FlaggedAction
    {
        public UpdateScentFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }

    }
    [Serializable]
    internal class UpdateSpellsFlaggedAction : FlaggedAction
    {
        public UpdateSpellsFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            throw new NotImplementedException();
        }

    }
    [Serializable]
    internal class UpdateTorchRadiusFlaggedAction : FlaggedAction
    {
        public UpdateTorchRadiusFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        /// <summary>
        /// Compute the level of light.  The player may be wielding multiple sources of light.
        /// </summary>
        protected override void Execute()
        {
            throw new NotImplementedException();
        }

    }
    [Serializable]
    internal class UpdateViewFlaggedAction : FlaggedAction
    {
        public UpdateViewFlaggedAction(SaveGame saveGame) : base(saveGame) { }

        protected override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
