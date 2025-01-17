﻿namespace AngbandOS.Core;

[Serializable]
internal class GenericSymbol : Symbol
{
    public GenericSymbol(Game game, SymbolGameConfiguration symbolDefinition) : base(game)
    {
        Character = symbolDefinition.Character;
        QueryCharacter = symbolDefinition.QueryCharacter;
        Name = symbolDefinition.Name;
        Key = symbolDefinition.Key;
    }

    public override char Character { get; }
    public override char? QueryCharacter { get; } = null;
    public override string Name { get; }
    public override string Key { get; }
}
