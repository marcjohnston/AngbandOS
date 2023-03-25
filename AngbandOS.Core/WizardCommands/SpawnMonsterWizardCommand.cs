namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal class SpawnMonsterWizardCommand : WizardCommand
    {
        private SpawnMonsterWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'O';

        public override string HelpDescription => "Spawn Monster";

        public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardMonstersHelpGroup>();

        public override void Execute()
        {
            SaveGame.WizSpawnMonster();
        }
    }
}
