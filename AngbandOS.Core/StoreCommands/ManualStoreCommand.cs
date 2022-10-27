using AngbandOS.Commands;
using System;

namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Show the game manual
    /// </summary>
    [Serializable]
    internal class ManualStoreCommand : IStoreCommand
    {
        public char Key => 'h';

        public bool IsEnabled(Store store) => true;

        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdManual(saveGame);
        }

        public static void DoCmdManual(SaveGame saveGame)
        {
            saveGame.ShowManual();
        }
    }
}
