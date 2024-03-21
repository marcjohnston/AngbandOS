
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerDSymbol : Symbol
{
    private LowerDSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'd';
    public override string Name => "Dragon";
}

