namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class SelfKnowledgeWizardCommand : WizardCommand
    {
        private SelfKnowledgeWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'k';

        public override void Execute()
        {
            SaveGame.SelfKnowledge();
        }
    }
}
