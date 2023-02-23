namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class CreateNamedArtWizardCommand : WizardCommand
    {
        private CreateNamedArtWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'C';

        public override void Execute()
        {
            SaveGame.WizCreateNamedArt((FixedArtifactId)SaveGame.CommandArgument);
        }
    }
}
