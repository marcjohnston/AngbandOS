// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestInPlaceScript : GameCommandUniversalScript, IGetKey
{
    private RestInPlaceScript(Game game) : base(game) { }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the rest script and returns false, if the resting is disturbed; true, if the rest was undisturbed.
    /// </summary>
    /// <returns></returns>
    public override RepeatableResultEnum ExecuteGameCommandScript()
    {
        if (Game.CommandArgument <= 0)
        {
            const string prompt = "Rest (0-9999, '*' for HP/SP, '&' as needed): ";
            if (!Game.GetString(prompt, out string choice, "&", 4))
            {
                return RepeatableResultEnum.False; // We are not returning by chance.  The user opted out.
            }

            // Default to resting until we're fine
            if (string.IsNullOrEmpty(choice))
            {
                choice = "&";
            }

            // -2 means rest until we're fine
            if (choice[0] == '&')
            {
                Game.CommandArgument = -2;
            }

            // -1 means rest until we're at full health, but don't worry about waiting for other
            // status effects to go away
            else if (choice[0] == '*')
            {
                Game.CommandArgument = -1;
            }
            else
            {
                // A number means rest for that many turns
                if (int.TryParse(choice, out int i))
                {
                    Game.CommandArgument = i;
                }

                // The player might not have put a number in - so abandon if they didn't
                if (Game.CommandArgument <= 0)
                {
                    return RepeatableResultEnum.False; // We are not returning by chance.  The user entered an invalid count.
                }
            }
        }

        // Can't rest for more than 9999 turns
        if (Game.CommandArgument > 9999)
        {
            Game.CommandArgument = 9999;
        }

        // Resting takes at least one turn (we'll also be skipping future turns)
        Game.EnergyUse = 100;
        Game.Resting = Game.CommandArgument;
        Game.IsSearching = false;
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawStateFlaggedAction)).Set();
        Game.HandleStuff();
        Game.UpdateScreen();
        return RepeatableResultEnum.True; // This can and should be repeated.
    }
}
