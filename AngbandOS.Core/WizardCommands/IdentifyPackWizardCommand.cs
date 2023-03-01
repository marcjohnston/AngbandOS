namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class IdentifyPackWizardCommand : WizardCommand
    {
        private IdentifyPackWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'i';

        public override string HelpDescription => "Identify Pack";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardObjectCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.IdentifyPack();
        }
    }
}
