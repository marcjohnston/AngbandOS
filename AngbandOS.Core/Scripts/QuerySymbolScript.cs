// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class QuerySymbolScript : Script, IScript, ICastSpellScript, IGameCommandScript, IStoreCommandScript
{
    private QuerySymbolScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the query symbol script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the query symbol script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the query symbol script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
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
