namespace AngbandOS.Core;

[Serializable]
internal sealed class Symbol : IGetKey, IToJson, IGameSerialize
{
    private Game Game { get; }
    public Symbol(Game game, SymbolGameConfiguration gameConfiguration) 
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        Character = gameConfiguration.Character;
        QueryCharacter = gameConfiguration.QueryCharacter;
        Name = gameConfiguration.Name;
    }
    public GameStateBag? Serialize(SaveGameState saveGameState) => null;

    public char Character { get; }

    /// <summary>
    /// Returns the symbol that the player specifies to query the symbol; or null, if the Character property is to be used.  Returns
    /// null, by default.  This symbol may be different from the character because the render character may not be easily typable.
    /// When a query charactter is specified, it works in conjuction with the character symbol; meaning, that both the character
    /// and the query character are both recognized.  The PeriodSymbol overrides this property.
    /// </summary>
    public char? QueryCharacter { get; } = null;

    public string Name { get; }

    public string Key { get; }
    public void Bind(RestoreGameState? restoreGameState) { }

    public string GetKey => Key;

    public string ToJson()
    {
        SymbolGameConfiguration symbolDefinition = new SymbolGameConfiguration()
        {
            Key = Key,
            Character = Character,
            QueryCharacter = QueryCharacter,
            Name = Name
        };
        return JsonSerializer.Serialize(symbolDefinition, Game.GetJsonSerializerOptions());
    }
}
