namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class CarnageTrueWizardCommand : WizardCommand
    {
        private CarnageTrueWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'Z';

        public override string HelpDescription => "Carnage True";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardMonstersHelpGroup>();

        public override void Execute()
        {
            SaveGame.DoCmdWizZap();
        }
    }
}
