// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class QuerySymbolScript : Script
{
    private QuerySymbolScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        // Query the user for the symbol to identify.
        if (!SaveGame.GetCom("Enter character to be identified: ", out char querySymbol))
        {
            return false;
        }

        // Run through the identification array till we find the symbol.
        foreach (Symbol symbol in SaveGame.SingletonRepository.Symbols)
        {
            if (querySymbol == symbol.Character)
            {
                SaveGame.MsgPrint($"{querySymbol} - {symbol.Name}");
                return false;
            }
        }

        // Display the symbol and its identification.
        SaveGame.MsgPrint($"{querySymbol} - Unknown Symbol");
        return false;
    }
}
