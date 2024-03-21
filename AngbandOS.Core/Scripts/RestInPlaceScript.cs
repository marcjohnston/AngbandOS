// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestInPlaceScript : Script, IScript, IRepeatableScript
{
    private RestInPlaceScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the rest script and disposes of the repeatable result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the rest script and returns false, if the resting is disturbed; true, if the rest was undisturbed.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        if (SaveGame.CommandArgument <= 0)
        {
            const string prompt = "Rest (0-9999, '*' for HP/SP, '&' as needed): ";
            if (!SaveGame.GetString(prompt, out string choice, "&", 4))
            {
                return false; // We are not returning by chance.  The user opted out.
            }

            // Default to resting until we're fine
            if (string.IsNullOrEmpty(choice))
            {
                choice = "&";
            }

            // -2 means rest until we're fine
            if (choice[0] == '&')
            {
                SaveGame.CommandArgument = -2;
            }

            // -1 means rest until we're at full health, but don't worry about waiting for other
            // status effects to go away
            else if (choice[0] == '*')
            {
                SaveGame.CommandArgument = -1;
            }
            else
            {
                // A number means rest for that many turns
                if (int.TryParse(choice, out int i))
                {
                    SaveGame.CommandArgument = i;
                }

                // The player might not have put a number in - so abandon if they didn't
                if (SaveGame.CommandArgument <= 0)
                {
                    return false; // We are not returning by chance.  The user entered an invalid count.
                }
            }
        }

        // Can't rest for more than 9999 turns
        if (SaveGame.CommandArgument > 9999)
        {
            SaveGame.CommandArgument = 9999;
        }

        // Resting takes at least one turn (we'll also be skipping future turns)
        SaveGame.EnergyUse = 100;
        SaveGame.Resting = SaveGame.CommandArgument;
        SaveGame.IsSearching = false;
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStateFlaggedAction)).Set();
        SaveGame.HandleStuff();
        SaveGame.UpdateScreen();
        return true; // This can and should repeated.
    }
}
