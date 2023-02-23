namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class SummonWizardCommand : WizardCommand
    {
        private SummonWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 's';

        public override void Execute()
        {
            if (SaveGame.CommandArgument <= 0)
            {
                SaveGame.CommandArgument = 1;
            }
            SaveGame.DoCmdWizSummon(SaveGame.CommandArgument);
        }
    }
}
