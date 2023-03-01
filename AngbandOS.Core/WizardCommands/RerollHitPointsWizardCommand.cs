using AngbandOS.Core.HelpGroups;

namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class RerollHitPointsWizardCommand : WizardCommand
    {
        private RerollHitPointsWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'h';

        public override string HelpDescription => "Reroll Hitpoints";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<CharacterEditingHelpGroup>();

        public override void Execute()
        {
            SaveGame.Player.RerollHitPoints();
        }
    }
}
