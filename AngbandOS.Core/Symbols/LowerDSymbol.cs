
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerDSymbol : Symbol
{
    private LowerDSymbol(Game game) : base(game) { }
    public override char Character => 'd';
    public override string Name => "Dragon";
}

