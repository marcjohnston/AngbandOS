namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class NamedFriendlyWizardCommand : WizardCommand
    {
        private NamedFriendlyWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'N';

        public override void Execute()
        {
            SaveGame.DoCmdWizNamedFriendly(SaveGame.CommandArgument, true);
        }
    }
}
