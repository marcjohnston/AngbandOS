namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class PhaseDoorWizardCommand : WizardCommand
    {
        private PhaseDoorWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'p';

        public override string HelpDescription => "Phase Door";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardMovementHelpGroup>();

        public override void Execute()
        {
            SaveGame.TeleportPlayer(10);
        }
    }
}
