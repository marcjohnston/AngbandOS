namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class GainMutationWizardCommand : WizardCommand
    {
        private GainMutationWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'M';

        public override string HelpDescription => "Gain Mutation";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<CharacterEditingHelpGroup>();

        public override void Execute()
        {
            SaveGame.Player.Dna.GainMutation();
        }
    }
}
