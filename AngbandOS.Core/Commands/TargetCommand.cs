using Cthangband.StaticData;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Select a target in advance for attacks. Note that this does not cost any in-game time
    /// </summary>
    [Serializable]
    internal class TargetCommand : ICommand
    {
        public char Key => '*';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            if (targetEngine.TargetSet(Constants.TargetKill))
            {
                saveGame.MsgPrint(saveGame.TargetWho > 0 ? "Target Selected." : "Location Targeted.");
            }
            else
            {
                saveGame.MsgPrint("Target Aborted.");
            }
        }
    }
}
