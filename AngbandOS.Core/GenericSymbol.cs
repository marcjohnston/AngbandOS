namespace AngbandOS.Core;

[Serializable]
internal class GenericSymbol : Symbol
{
    public GenericSymbol(Game game, SymbolGameConfiguration symbolGameConfiguration) : base(game)
    {
        Character = symbolGameConfiguration.Character;
        QueryCharacter = symbolGameConfiguration.QueryCharacter;
        Name = symbolGameConfiguration.Name;
        Key = symbolGameConfiguration.Key ?? symbolGameConfiguration.GetType().Name;
    }

    public override char Character { get; }
    public override char? QueryCharacter { get; } = null;
    public override string Name { get; }
    public override string Key { get; }
}
