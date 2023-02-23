namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class RedrawWizardCommand : WizardCommand
    {
        private RedrawWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'R';

        public override void Execute()
        {
            SaveGame.DoCmdRedraw();
        }
    }
}
