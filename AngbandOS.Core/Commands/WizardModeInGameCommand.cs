namespace AngbandOS.Core.Commands
{
    [Serializable]
    internal class WizardModeInGameCommand : InGameCommand
    {
        private WizardModeInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

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
                SaveGame.EnterWizardMode();
            }
            return false;
        }
    }
}
