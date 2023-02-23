namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class GainExperienceWizardCommand : WizardCommand
    {
        private GainExperienceWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'x';

        public override void Execute()
        {
            if (SaveGame.CommandArgument != 0)
            {
                SaveGame.Player.GainExperience(SaveGame.CommandArgument);
            }
            else
            {
                SaveGame.Player.GainExperience(SaveGame.Player.ExperiencePoints + 1);
            }
        }
    }
}
