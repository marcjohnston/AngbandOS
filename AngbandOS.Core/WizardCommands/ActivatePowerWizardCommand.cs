namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class ActivatePowerWizardCommand : WizardCommand
    {
        private ActivatePowerWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'A';

        public override void Execute()
        {
            SaveGame.DoCmdWizActivatePower();
        }
    }
}
