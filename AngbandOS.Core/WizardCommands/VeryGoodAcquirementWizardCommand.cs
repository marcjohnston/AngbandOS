namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class VeryGoodAcquirementWizardCommand : WizardCommand
    {
        private VeryGoodAcquirementWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'v';

        public override void Execute()
        {
            if (SaveGame.CommandArgument <= 0)
            {
                SaveGame.CommandArgument = 1;
            }
            SaveGame.Level.Acquirement(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.CommandArgument, true);
        }
    }
}
