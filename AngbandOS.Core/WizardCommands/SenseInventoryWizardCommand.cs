namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class SenseInventoryWizardCommand : WizardCommand
    {
        private SenseInventoryWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'S';

        public override void Execute()
        {
            SaveGame.Player.SenseInventory();
        }
    }
}
