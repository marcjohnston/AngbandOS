namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class SpoilersWizardCommand : WizardCommand
    {
        private SpoilersWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '"';

        public override bool IsEnabled => false;

        public override void Execute()
        {
        }
    }
}
