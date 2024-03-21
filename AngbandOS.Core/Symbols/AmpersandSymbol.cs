
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class AmpersandSymbol : Symbol
{
    private AmpersandSymbol(Game game) : base(game) { }
    public override char Character => '&';
    public override string Name => "Entrance to Inn";
}

