namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class JumpWizardCommand : WizardCommand
    {
        private JumpWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'j';

        public override void Execute()
        {
            SaveGame.DoCmdWizJump();
        }
    }
}
