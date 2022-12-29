namespace AngbandOS.Commands
{
    /// <summary>
    /// Rest for either a fixed amount of time or until back to max health and mana
    /// </summary>
    [Serializable]
    internal class RestCommand : ICommand
    {
        private RestCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'R';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            if (saveGame.CommandArgument <= 0)
            {
                const string prompt = "Rest (0-9999, '*' for HP/SP, '&' as needed): ";
                if (!saveGame.GetString(prompt, out string choice, "&", 4))
                {
                    return;
                }
                // Default to resting until we're fine
                if (string.IsNullOrEmpty(choice))
                {
                    choice = "&";
                }
                // -2 means rest until we're fine
                if (choice[0] == '&')
                {
                    saveGame.CommandArgument = -2;
                }
                // -1 means rest until we're at full health, but don't worry about waiting for other
                // status effects to go away
                else if (choice[0] == '*')
                {
                    saveGame.CommandArgument = -1;
                }
                else
                {
                    // A number means rest for that many turns
                    if (int.TryParse(choice, out int i))
                    {
                        saveGame.CommandArgument = i;
                    }
                    // The player might not have put a number in - so abandon if they didn't
                    if (saveGame.CommandArgument <= 0)
                    {
                        return;
                    }
                }
            }
            // Can't rest for more than 9999 turns
            if (saveGame.CommandArgument > 9999)
            {
                saveGame.CommandArgument = 9999;
            }
            // Resting takes at least one turn (we'll also be skipping future turns)
            saveGame.EnergyUse = 100;
            saveGame.Resting = saveGame.CommandArgument;
            saveGame.Player.IsSearching = false;
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrState);
            saveGame.HandleStuff();
            saveGame.UpdateScreen();
        }
    }
}
