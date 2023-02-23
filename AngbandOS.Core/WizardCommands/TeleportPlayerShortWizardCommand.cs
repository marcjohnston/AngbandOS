namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class TeleportPlayerShortWizardCommand : WizardCommand
    {
        private TeleportPlayerShortWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'p';

        public override void Execute()
        {
            SaveGame.TeleportPlayer(10);
        }
    }
}
