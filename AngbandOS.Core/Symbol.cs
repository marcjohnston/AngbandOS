namespace AngbandOS.Core;

[Serializable]
internal sealed class Symbol : IGetKey, IToJson
{
    private readonly Game Game;
    public Symbol(Game game, SymbolGameConfiguration symbolGameConfiguration) 
    {
        Game = game;
        Character = symbolGameConfiguration.Character;
        QueryCharacter = symbolGameConfiguration.QueryCharacter;
        Name = symbolGameConfiguration.Name;
        Key = symbolGameConfiguration.Key ?? symbolGameConfiguration.GetType().Name;
    }
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
    public void Bind() { }

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
