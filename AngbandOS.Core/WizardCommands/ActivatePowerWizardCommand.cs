namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class ActivatePowerWizardCommand : WizardCommand
    {
        private ActivatePowerWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'A';

        public override string HelpDescription => "Activate Power";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<GeneralCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.DoCmdWizActivatePower();
        }
    }
}
