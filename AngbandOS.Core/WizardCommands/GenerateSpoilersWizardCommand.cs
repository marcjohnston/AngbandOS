namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class GenerateSpoilersWizardCommand : WizardCommand
    {
        private GenerateSpoilersWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '"';

        public override string HelpDescription => "Generate Spoilers";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<GeneralCommandsHelpGroup>();

        public override bool IsEnabled => false;

        public override void Execute()
        {
        }
    }
}
