namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class WinTheGameWizardCommand : WizardCommand
    {
        private WinTheGameWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'W';

        public override string HelpDescription => "Win the Game";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardGeneralCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.Winner();
        }
    }
}
