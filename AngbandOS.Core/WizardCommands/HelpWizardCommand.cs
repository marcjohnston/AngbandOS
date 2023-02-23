namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class HelpWizardCommand : WizardCommand
    {
        private HelpWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '?';

        public override void Execute()
        {
            SaveGame.DoCmdWizHelp();
        }
    }
}
