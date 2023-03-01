namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class GenerateGoodObjectWizardCommand : WizardCommand
    {
        private GenerateGoodObjectWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'g';

        public override string HelpDescription => "Generate Good Object";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardObjectCommandsHelpGroup>();

        public override void Execute()
        {
            if (SaveGame.CommandArgument <= 0)
            {
                SaveGame.CommandArgument = 1;
            }
            SaveGame.Level.Acquirement(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.CommandArgument, false);
        }
    }
}
