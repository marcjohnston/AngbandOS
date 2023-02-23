namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class IdentifyFullyWizardCommand : WizardCommand
    {
        private IdentifyFullyWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'f';

        public override void Execute()
        {
            SaveGame.IdentifyFully();
        }
    }
}
