﻿namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Destroy all worthless items in your pack
    /// </summary>
    [Serializable]
    internal class DestroyAllGameCommand : GameCommand
    {
        private DestroyAllGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'K';

        public override bool Execute()
        {
            SaveGame.DoCmdDestroyAll();
            return false;
        }
    }
}