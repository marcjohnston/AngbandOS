// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class QuerySymbolScript : Script
    {
        private QuerySymbolScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            int index;
            // Get the symbol
            if (!SaveGame.GetCom("Enter character to be identified: ", out char symbol))
            {
                return false;
            }
            // Run through the identification array till we find the symbol
            for (index = 0; Constants.SymbolIdentification[index] != null; ++index)
            {
                if (symbol == Constants.SymbolIdentification[index][0])
                {
                    break;
                }
            }
            // Display the symbol and its idenfitication
            string buf = Constants.SymbolIdentification[index] != null
                ? $"{symbol} - {Constants.SymbolIdentification[index].Substring(2)}."
                : $"{symbol} - Unknown Symbol";
            SaveGame.MsgPrint(buf);
            return false;
        }
    }
}
