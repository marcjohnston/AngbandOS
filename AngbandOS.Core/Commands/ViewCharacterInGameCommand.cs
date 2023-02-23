namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// View the character sheet
    /// </summary>
    [Serializable]
    internal class ViewCharacterInGameCommand : InGameCommand
    {
        private ViewCharacterInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'C';

        public override bool Execute()
        {
            SaveGame.DoCmdViewCharacter();
            return false;
        }
    }
}
