namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class EditWizardCommand : WizardCommand
    {
        private EditWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'e';

        public override void Execute()
        {
            SaveGame.DoCmdWizChange();
        }
    }
}
