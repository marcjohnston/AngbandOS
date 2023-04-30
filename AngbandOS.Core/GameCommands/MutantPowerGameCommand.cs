namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Use a mutant or racial power
    /// </summary>
    [Serializable]
    internal class MutantPowerGameCommand : GameCommand
    {
        private MutantPowerGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'p';

        public override bool Execute()
        {
            SaveGame.DoCmdMutantPower();
            return false;
        }
    }
}
