
namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperSSymbol : Symbol
{
    private UpperSSymbol(Game game) : base(game) { }
    public override char Character => 'S';
    public override string Name => "Spider/Scorpion/Tick";
}

