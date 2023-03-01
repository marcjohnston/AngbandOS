namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class IdentifyFullyWizardCommand : WizardCommand
    {
        private IdentifyFullyWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'f';

        public override string HelpDescription => "Identify Fully";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<ObjectCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.IdentifyFully();
        }
    }
}
