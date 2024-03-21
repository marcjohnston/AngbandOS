
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class DoubleQuoteSymbol : Symbol
{
    private DoubleQuoteSymbol(Game game) : base(game) { }
    public override char Character => '"';
    public override string Name => "An amulet (or necklace)";
}

