
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerXSymbol : Symbol
{
    private LowerXSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'x';
    public override string Name => "Xorn/Xaren/etc";
}

