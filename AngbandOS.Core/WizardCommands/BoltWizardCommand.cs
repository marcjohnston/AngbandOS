namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class BoltWizardCommand : WizardCommand
    {
        private BoltWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'z';

        public override void Execute()
        {
            SaveGame.DoCmdWizardBolt();
        }
    }
}
