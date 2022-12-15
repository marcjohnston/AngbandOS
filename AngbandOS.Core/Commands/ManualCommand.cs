using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Show the game manual
    /// </summary>
    [Serializable]
    internal class ManualCommand : ICommand
    {
        public char Key => 'h';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            ManualStoreCommand.DoCmdManual(saveGame);
        }
    }
}
