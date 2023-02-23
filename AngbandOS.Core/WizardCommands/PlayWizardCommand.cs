namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class PlayWizardCommand : WizardCommand
    {
        private PlayWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'o';

        public override void Execute()
        {
            SaveGame.DoCmdWizPlay();
        }
    }
}
