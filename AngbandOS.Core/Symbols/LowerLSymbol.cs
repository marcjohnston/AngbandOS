
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerLSymbol : Symbol
{
    private LowerLSymbol(Game game) : base(game) { }
    public override char Character => 'l';
    public override string Name => "Louse";
}

