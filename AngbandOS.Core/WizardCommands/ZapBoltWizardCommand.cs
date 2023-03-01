namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class ZapBoltWizardCommand : WizardCommand
    {
        private ZapBoltWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'z';

        public override string HelpDescription => "Zap (Wizard Bolt)";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardMonstersHelpGroup>();

        public override void Execute()
        {
            SaveGame.DoCmdWizardBolt();
        }
    }
}
