// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnterWizardModeScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private EnterWizardModeScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the wizard mode script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the wizard mode script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.IsWizard.BoolValue)
        {
            Game.GetCom("Wizard Command: ", out char cmd);
            foreach (WizardCommand wizardCommand in Game.SingletonRepository.Get<WizardCommand>())
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
            string? tmp = Game.AskforAux("", 31);
            Game.Screen.Erase(0, 0);
            if (tmp == "Dumbledore")
            {
                Game.IsWizard.BoolValue = true;
                Game.MsgPrint("Wizard mode activated.");
            }
        }
    }
}
