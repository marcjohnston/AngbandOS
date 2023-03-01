namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class DetectAllWizardCommand : WizardCommand
    {
        private DetectAllWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'd';

        public override string HelpDescription => "Detect All";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardGeneralCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.DetectAll();
        }
    }
}
