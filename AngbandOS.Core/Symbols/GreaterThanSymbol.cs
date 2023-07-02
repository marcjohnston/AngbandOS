
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class GreaterThanSymbol : Symbol
{
    private GreaterThanSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '>';
    public override string Name => "A down staircase";
}

