namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class HelpWizardCommand : WizardCommand
    {
        private HelpWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '?';

        public override string HelpDescription => "Render Wizard Help";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardGeneralCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.DoCmdWizHelp();
        }
    }
}
