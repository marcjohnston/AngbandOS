namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class WinnerWizardCommand : WizardCommand
    {
        private WinnerWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'W';

        public override void Execute()
        {
            SaveGame.Winner();
        }
    }
}
