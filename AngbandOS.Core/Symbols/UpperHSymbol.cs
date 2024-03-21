namespace AngbandOS.Core.Symbols;

[Serializable]
internal class UpperHSymbol : Symbol
{
    private UpperHSymbol(Game game) : base(game) { }
    public override char Character => 'H';
    public override string Name => "Hybrid";
}
