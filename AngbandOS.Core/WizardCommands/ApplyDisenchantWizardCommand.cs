namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class ApplyDisenchantWizardCommand : WizardCommand
    {
        private ApplyDisenchantWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'D';

        public override string HelpDescription => "Disenchant an Item";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardObjectCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.ApplyDisenchant();
        }
    }
}
