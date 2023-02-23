namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class GainMutationWizardCommand : WizardCommand
    {
        private GainMutationWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'M';

        public override void Execute()
        {
            SaveGame.Player.Dna.GainMutation();
        }
    }
}
