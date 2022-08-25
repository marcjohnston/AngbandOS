using Cthangband.Commands;
using Cthangband.StaticData;
using Cthangband.UI;
using System;

namespace Cthangband.StoreCommands
{
    /// <summary>
    /// Show the player what a particular symbol represents
    /// </summary>
    [Serializable]
    internal class QuerySymbolStoreCommand : IStoreCommand
    {
        public char Key => '/';

        public bool IsEnabled(Store store) => true;

        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdQuerySymbol(saveGame);
        }

        public static void DoCmdQuerySymbol(SaveGame saveGame)
        {
            int index;
            // Get the symbol
            if (!saveGame.GetCom("Enter character to be identified: ", out char symbol))
            {
                return;
            }
            // Run through the identification array till we find the symbol
            for (index = 0; GlobalData.SymbolIdentification[index] != null; ++index)
            {
                if (symbol == GlobalData.SymbolIdentification[index][0])
                {
                    break;
                }
            }
            // Display the symbol and its idenfitication
            string buf = GlobalData.SymbolIdentification[index] != null
                ? $"{symbol} - {GlobalData.SymbolIdentification[index].Substring(2)}."
                : $"{symbol} - Unknown Symbol";
            saveGame.MsgPrint(buf);
        }
    }
}
