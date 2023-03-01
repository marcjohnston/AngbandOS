namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class TeleportWizardCommand : WizardCommand
    {
        private TeleportWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 't';

        public override string HelpDescription => "Teleport";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<MovementHelpGroup>();

        public override void Execute()
        {
            SaveGame.TeleportPlayer(100);
        }
    }
}
