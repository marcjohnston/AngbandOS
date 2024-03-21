
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperBSymbol : Symbol
{
    private UpperBSymbol(Game game) : base(game) { }
    public override char Character => 'B';
    public override string Name => "Bird";
}

