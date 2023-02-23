namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class CureAllWizardCommand : WizardCommand
    {
        private CureAllWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'a';

        public override void Execute()
        {
            SaveGame.DoCmdWizCureAll();
        }
    }
}
