namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class SenseInventoryWizardCommand : WizardCommand
    {
        private SenseInventoryWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'S';

        public override string HelpDescription => "Sense Inventory";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardObjectCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.Player.SenseInventory();
        }
    }
}
