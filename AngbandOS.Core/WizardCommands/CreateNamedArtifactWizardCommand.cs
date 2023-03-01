namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class CreateNamedArtifactWizardCommand : WizardCommand
    {
        private CreateNamedArtifactWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'C';

        public override string HelpDescription => "Create Named Artifact";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<ObjectCommandsHelpGroup>();

        public override void Execute()
        {
            SaveGame.WizCreateNamedArt((FixedArtifactId)SaveGame.CommandArgument);
        }
    }
}
