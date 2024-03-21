
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperFSymbol : Symbol
{
    private UpperFSymbol(Game game) : base(game) { }
    public override char Character => 'F';
    public override string Name => "Dragon Fly";
}

