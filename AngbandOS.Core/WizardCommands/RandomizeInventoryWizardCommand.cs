namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class RandomizeInventoryWizardCommand : WizardCommand
    {
        private RandomizeInventoryWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'X';

        public override void Execute()
        {
            SaveGame.RandomizeInventory();
        }
    }
}
