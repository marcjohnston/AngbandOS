namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class ObjectEditorWizardCommand : WizardCommand
    {
        private ObjectEditorWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'o';

        public override string HelpDescription => "Object Editor";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardObjectCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.DoCmdWizPlay();
        }
    }
}
