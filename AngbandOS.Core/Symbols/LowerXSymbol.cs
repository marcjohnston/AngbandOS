
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerXSymbol : Symbol
{
    private LowerXSymbol(Game game) : base(game) { }
    public override char Character => 'x';
    public override string Name => "Xorn/Xaren/etc";
}

