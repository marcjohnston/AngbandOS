namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class SpaceWizardCommand : WizardCommand
    {
        private SpaceWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => ' ';

        public override void Execute()
        {
        }
    }
}
