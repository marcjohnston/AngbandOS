namespace AngbandOS.Commands
{
    /// <summary>
    /// View the character sheet
    /// </summary>
    [Serializable]
    internal class ViewCharacterCommand : Command
    {
        private ViewCharacterCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'C';

        public override bool Execute()
        {
            SaveGame.DoCmdViewCharacter();
            return false;
        }
    }
}
