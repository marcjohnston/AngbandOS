﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RetireScript : Script, IScript, IRepeatableScript
{
    private RetireScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the retire script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the retire script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // If we're a winner it's a simple question with a more positive connotation
        if (Game.IsWinner.Value)
        {
            if (!Game.GetCheck("Do you want to retire? "))
            {
                return;
            }
        }
        else
        {
            // If we're not a winner, only ask if we're not also a wizard - giving up a wizard
            // character doesn't need a prompt/confirmation
            if (!Game.IsWizard.Value)
            {
                if (!Game.GetCheck("Do you really want to give up? "))
                {
                    return;
                }
                // Require a confirmation to make sure the player doesn't accidentally give up a
                // long-running character
                Game.Screen.PrintLine("Type the '@' sign to give up (this character will no longer be playable): ", 0, 0);
                int i = Game.Inkey();
                Game.MsgClear();
                if (i != '@')
                {
                    return;
                }
            }
            else
            {
                if (!Game.GetCheck("Do you really want to quit? "))
                {
                    return;
                }
            }
        }
        // Assuming whe player didn't give up, "kill" the character by quitting
        Game.Playing = false;
        Game.IsDead = true;
        Game.DiedFrom = "quitting";
    }
}