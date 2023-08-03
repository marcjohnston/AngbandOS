
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class DoubleQuoteSymbol : Symbol
{
    private DoubleQuoteSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '"';
    public override string Name => "An amulet (or necklace)";
}

