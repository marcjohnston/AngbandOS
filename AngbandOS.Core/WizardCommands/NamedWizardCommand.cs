namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class NamedWizardCommand : WizardCommand
    {
        private NamedWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'n';

        public override void Execute()
        {
            SaveGame.DoCmdWizNamed(SaveGame.CommandArgument, true);
        }
    }
}
