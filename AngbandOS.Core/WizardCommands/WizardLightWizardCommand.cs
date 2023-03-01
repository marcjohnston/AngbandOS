namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class WizardLightWizardCommand : WizardCommand
    {
        private WizardLightWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'w';

        public override string HelpDescription => "Wizard Light";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<GeneralCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.Level.WizLight();
        }
    }
}
