using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// View the character sheet
    /// </summary>
    [Serializable]
    internal class ViewCharacterCommand : ICommand
    {
        private ViewCharacterCommand() { } // This object is a singleton.

        public char Key => 'C';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            ViewCharacterStoreCommand.DoCmdViewCharacter(saveGame);
        }
    }
}
