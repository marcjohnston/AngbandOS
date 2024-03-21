
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UnderscoreSymbol : Symbol
{
    private UnderscoreSymbol(Game game) : base(game) { }
    public override char Character => '_';
    public override string Name => "A staff";
}

