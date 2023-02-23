namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class SummonHordeWizardCommand : WizardCommand
    {
        private SummonHordeWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'H';

        public override void Execute()
        {
            SaveGame.DoCmdSummonHorde();
        }
    }
}
