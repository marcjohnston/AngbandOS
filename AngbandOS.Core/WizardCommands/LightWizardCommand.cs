namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class LightWizardCommand : WizardCommand
    {
        private LightWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'w';

        public override void Execute()
        {
            SaveGame.Level.WizLight();
        }
    }
}
