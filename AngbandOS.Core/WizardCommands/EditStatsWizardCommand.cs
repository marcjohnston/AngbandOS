namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class EditStatsWizardCommand : WizardCommand
    {
        private EditStatsWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'e';

        public override string HelpDescription => "Edit Stats";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<CharacterEditingHelpGroup>();

        public override void Execute()
        {
            SaveGame.DoCmdWizChange();
        }
    }
}
