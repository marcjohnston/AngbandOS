
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperJSymbol : Symbol
{
    private UpperJSymbol(Game game) : base(game) { }
    public override char Character => 'J';
    public override string Name => "Snake";
}

