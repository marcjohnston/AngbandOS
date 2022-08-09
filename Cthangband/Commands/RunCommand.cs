using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Start running
    /// </summary>
    [Serializable]
    internal class RunCommand : ICommand
    {
        public char Key => '.';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            // Can't run if we're confused
            if (saveGame.Player.TimedConfusion != 0)
            {
                SaveGame.Instance.MsgPrint("You are too confused!");
                return;
            }
            // Get a direction if we don't already have one
            if (targetEngine.GetDirectionNoAim(out int dir))
            {
                // If we don't have a distance, assume we'll run for 1,000 steps
                SaveGame.Instance.Running = Gui.CommandArgument != 0 ? Gui.CommandArgument : 1000;
                // Run one step in the chosen direction
                SaveGame.Instance.RunOneStep(dir);
            }
        }
    }
}
