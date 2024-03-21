
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class GreaterThanSymbol : Symbol
{
    private GreaterThanSymbol(Game game) : base(game) { }
    public override char Character => '>';
    public override string Name => "A down staircase";
}

