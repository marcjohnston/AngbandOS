using Cthangband.Commands;
using Cthangband.UI;
using System;

namespace Cthangband.StoreCommands
{
    /// <summary>
    /// Show the previous message
    /// </summary>
    [Serializable]
    internal class MessageOneStoreCommand : IStoreCommand
    {
        public char Key => 'O';

        public bool IsEnabled(Store store) => true;

        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(Player player, Store store)
        {
            DoCmdMessageOne();
        }

        public static void DoCmdMessageOne()
        {
            Gui.PrintLine($"> {SaveGame.Instance.MessageStr(0)}", 0, 0);
        }
    }
}
