namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class EscapeWizardCommand : WizardCommand
    {
        private EscapeWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '\x1b';

        public override void Execute()
        {
        }
    }
}
