// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class RetireScript : Script
    {
        private RetireScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            // If we're a winner it's a simple question with a more positive connotation
            if (SaveGame.Player.IsWinner)
            {
                if (!SaveGame.GetCheck("Do you want to retire? "))
                {
                    return false;
                }
            }
            else
            {
                // If we're not a winner, only ask if we're not also a wizard - giving up a wizard
                // character doesn't need a prompt/confirmation
                if (!SaveGame.Player.IsWizard)
                {
                    if (!SaveGame.GetCheck("Do you really want to give up? "))
                    {
                        return false;
                    }
                    // Require a confirmation to make sure the player doesn't accidentally give up a
                    // long-running character
                    SaveGame.Screen.PrintLine("Type the '@' sign to give up (this character will no longer be playable): ", 0, 0);
                    int i = SaveGame.Inkey();
                    SaveGame.Screen.PrintLine("", 0, 0);
                    if (i != '@')
                    {
                        return false;
                    }
                }
            }
            // Assuming whe player didn't give up, "kill" the character by quitting
            SaveGame.Playing = false;
            SaveGame.Player.IsDead = true;
            SaveGame.DiedFrom = "quitting";
            return false;
        }
    }
}
