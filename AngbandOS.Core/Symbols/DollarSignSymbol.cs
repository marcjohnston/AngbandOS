namespace AngbandOS.Core.Symbols;

[Serializable]
internal class DollarSignSymbol : Symbol
{
    private DollarSignSymbol(Game game) : base(game) { }
    public override char Character => '$';
    public override string Name => "Treasure (gold or gems)";
}
