// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnterWizardModeScript : Script, IScript, IRepeatableScript
{
    private EnterWizardModeScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the wizard mode script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the wizard mode script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.IsWizard.Value)
        {
            Game.GetCom("Wizard Command: ", out char cmd);
            foreach (WizardCommand wizardCommand in Game.SingletonRepository.WizardCommands)
            {
                if (wizardCommand.IsEnabled && wizardCommand.KeyChar == cmd)
                {
                    if (wizardCommand.ExecuteScript != null)
                    {
                        wizardCommand.ExecuteScript.ExecuteScript();
                    }
                    return;
                }
            }
            Game.MsgPrint("That is not a valid wizard command.");
        }
        else
        {
            Game.Screen.PrintLine("Enter Wizard Code: ", 0, 0);
            if (!Game.AskforAux(out string tmp, "", 31))
            {
                Game.Screen.Erase(0, 0);
                return;
            }
            Game.Screen.Erase(0, 0);
            if (tmp == "Dumbledore")
            {
                Game.IsWizard.Value = true;
                Game.MsgPrint("Wizard mode activated.");
            }
        }
    }
}
