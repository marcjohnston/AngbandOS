namespace AngbandOS.Commands
{
    /// <summary>
    /// Retire (if a winner) or give up (if not a winner)
    /// </summary>
    [Serializable]
    internal class RetireCommand : ICommand
    {
        private RetireCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'Q';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            // If we're a winner it's a simple question with a more positive connotation
            if (saveGame.Player.IsWinner)
            {
                if (!saveGame.GetCheck("Do you want to retire? "))
                {
                    return;
                }
            }
            else
            {
                // If we're not a winner, only ask if we're not also a wizard - giving up a wizard
                // character doesn't need a prompt/confirmation
                if (!saveGame.Player.IsWizard)
                {
                    if (!saveGame.GetCheck("Do you really want to give up? "))
                    {
                        return;
                    }
                    // Require a confirmation to make sure the player doesn't accidentally give up a
                    // long-running character
                    saveGame.PrintLine("Type the '@' sign to give up (this character will no longer be playable): ", 0, 0);
                    int i = saveGame.Inkey();
                    saveGame.PrintLine("", 0, 0);
                    if (i != '@')
                    {
                        return;
                    }
                }
            }
            // Assuming whe player didn't give up, "kill" the character by quitting
            saveGame.Playing = false;
            saveGame.Player.IsDead = true;
            saveGame.DiedFrom = "quitting";
        }
    }
}
