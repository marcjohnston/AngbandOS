
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerPSymbol : Symbol
{
    private LowerPSymbol(Game game) : base(game) { }
    public override char Character => 'p';
    public override string Name => "Person/Human";
}

