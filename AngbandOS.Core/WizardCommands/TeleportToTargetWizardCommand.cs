namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class TeleportToTargetWizardCommand : WizardCommand
    {
        private TeleportToTargetWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'b';

        public override string HelpDescription => "Teleport to Target";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<MovementHelpGroup>();

        public override void Execute()
        {
            SaveGame.DoCmdWizBamf();
        }
    }
}
