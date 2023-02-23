namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class RerollHitPointsWizardCommand : WizardCommand
    {
        private RerollHitPointsWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'h';

        public override void Execute()
        {
            SaveGame.Player.RerollHitPoints();
        }
    }
}
