﻿namespace AngbandOS.Core.AlterActions
{
    [Serializable]
    internal class TunnelAlterAction : AlterAction
    {
        public override void Execute(AlterEventArgs alterEventArgs)
        {
            alterEventArgs.Disturbed = true;
            alterEventArgs.SaveGame.TunnelThroughTile(alterEventArgs.Y, alterEventArgs.X);
        }
    }
}