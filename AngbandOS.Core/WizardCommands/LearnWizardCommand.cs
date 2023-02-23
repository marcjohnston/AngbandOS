namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class LearnWizardCommand : WizardCommand
    {
        private LearnWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'l';

        public override void Execute()
        {
            SaveGame.DoCmdWizLearn();
        }
    }
}
