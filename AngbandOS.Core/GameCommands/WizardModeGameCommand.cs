// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Commands;

[Serializable]
internal class WizardModeGameCommand : GameCommand
{
    private WizardModeGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'W';

    public override bool Execute()
    {
        if (SaveGame.Player.IsWizard)
        {
            SaveGame.GetCom("Wizard Command: ", out char cmd);
            foreach (WizardCommand wizardCommand in SaveGame.SingletonRepository.WizardCommands)
            {
                if (wizardCommand.IsEnabled && wizardCommand.Key == cmd)
                {
                    wizardCommand.Execute();
                    return false;
                }
            }
            SaveGame.MsgPrint("That is not a valid wizard command.");
        }
        else
        {
            SaveGame.RunScript<EnterWizardModeScript>();
        }
        return false;
    }
}
