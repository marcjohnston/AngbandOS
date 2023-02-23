namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class CarriageReturnWizardCommand : WizardCommand
    {
        private CarriageReturnWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '\r';

        public override void Execute()
        {
        }
    }
}
