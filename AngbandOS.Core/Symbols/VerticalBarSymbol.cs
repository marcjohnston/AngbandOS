
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class VerticalBarSymbol : Symbol
{
    private VerticalBarSymbol(Game game) : base(game) { }
    public override char Character => '|';
    public override string Name => "An edged weapon (sword/dagger/etc)";
}

