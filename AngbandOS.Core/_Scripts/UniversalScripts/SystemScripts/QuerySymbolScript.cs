// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class QuerySymbolScript : UniversalScript, IGetKey
{
    private QuerySymbolScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the query symbol script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        // Query the user for the symbol to identify.
        if (!Game.GetCom("Enter character to be identified: ", out char querySymbol))
        {
            return;
        }

        // Run through the identification array till we find the symbol.
        bool found = false;
        foreach (Symbol symbol in Game.SingletonRepository.Get<Symbol>())
        {
            if (querySymbol == symbol.Character || querySymbol == symbol.QueryCharacter)
            {
                Game.MsgPrint($"{querySymbol} - {symbol.Name}");
                found = true;
            }
        }

        if (!found)
        {
            // Display the symbol and its identification.
            Game.MsgPrint($"{querySymbol} - Unknown Symbol");
        }
    }
}
