namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class GainLevelRewardWizardCommand : WizardCommand
    {
        private GainLevelRewardWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'r';

        public override void Execute()
        {
            SaveGame.Player.GainLevelReward();
        }
    }
}
