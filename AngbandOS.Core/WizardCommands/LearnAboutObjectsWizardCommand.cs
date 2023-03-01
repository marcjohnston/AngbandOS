namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class LearnAboutObjectsWizardCommand : WizardCommand
    {
        private LearnAboutObjectsWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'l';

        public override string HelpDescription => "Learn About Objects";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<ObjectCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.DoCmdWizLearn();
        }
    }
}
