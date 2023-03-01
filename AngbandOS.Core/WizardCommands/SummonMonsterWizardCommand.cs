namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class SummonMonsterWizardCommand : WizardCommand
    {
        private SummonMonsterWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 's';

        public override string HelpDescription => "Summon Monster";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardMonstersHelpGroup>();

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
