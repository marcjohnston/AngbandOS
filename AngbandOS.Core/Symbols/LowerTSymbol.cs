
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerTSymbol : Symbol
{
    private LowerTSymbol(Game game) : base(game) { }
    public override char Character => 't';
    public override string Name => "Townsperson";
}

