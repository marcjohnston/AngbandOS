namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class BamfWizardCommand : WizardCommand
    {
        private BamfWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'b';

        public override void Execute()
        {
            SaveGame.DoCmdWizBamf();
        }
    }
}
