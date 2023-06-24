// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class TargetScript : Script
    {
        private TargetScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            if (SaveGame.TargetSet(Constants.TargetKill))
            {
                SaveGame.MsgPrint(SaveGame.TargetWho > 0 ? "Target Selected." : "Location Targeted.");
            }
            else
            {
                SaveGame.MsgPrint("Target Aborted.");
            }
            return false;
        }
    }
}
