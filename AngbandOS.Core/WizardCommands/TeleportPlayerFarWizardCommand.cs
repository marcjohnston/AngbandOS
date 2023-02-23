namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class TeleportPlayerFarWizardCommand : WizardCommand
    {
        private TeleportPlayerFarWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 't';

        public override void Execute()
        {
            SaveGame.TeleportPlayer(100);
        }
    }
}
