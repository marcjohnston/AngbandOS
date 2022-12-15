using AngbandOS.Core;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Look around (using the target code) stopping on anything interesting rather than just
    /// things that can be targeted
    /// </summary>
    [Serializable]
    internal class LookCommand : ICommand
    {
        public char Key => 'l';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            if (saveGame.TargetSet(Constants.TargetLook))
            {
                saveGame.MsgPrint(saveGame.TargetWho > 0 ? "Target Selected." : "Location Targeted.");
            }
        }
    }
}
