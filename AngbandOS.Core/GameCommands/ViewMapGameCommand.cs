﻿namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Display a map of the area on screen
    /// </summary>
    [Serializable]
    internal class ViewMapGameCommand : GameCommand
    {
        private ViewMapGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'M';

        public override bool Execute()
        {
            SaveGame.DoViewMap();
            return false;
        }
    }
}