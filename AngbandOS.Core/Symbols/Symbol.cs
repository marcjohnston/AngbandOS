using System.Text.Json;

namespace AngbandOS.Core.Symbols;

[Serializable]
internal abstract class Symbol : IGetKey
{
    protected readonly Game Game;
    protected Symbol(Game game)
    {
        Game = game;
    }
    
    public abstract char Character { get; }

    /// <summary>
    /// Returns the symbol that the player specifies to query the symbol; or null, if the Character property is to be used.  Returns
    /// null, by default.  This symbol may be different from the character because the render character may not be easily typable.
    /// When a query charactter is specified, it works in conjuction with the character symbol; meaning, that both the character
    /// and the query character are both recognized.  The PeriodSymbol overrides this property.
    /// </summary>
    public virtual char? QueryCharacter => null;

    public abstract string Name { get; }

    public virtual string Key => GetType().Name;
    public virtual void Bind() { }

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
