namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class ZapWizardCommand : WizardCommand
    {
        private ZapWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'Z';

        public override void Execute()
        {
            SaveGame.DoCmdWizZap();
        }
    }
}
