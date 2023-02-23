namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class CreateItemWizardCommand : WizardCommand
    {
        private CreateItemWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'c';

        public override void Execute()
        {
            SaveGame.WizCreateItem();
        }
    }
}
