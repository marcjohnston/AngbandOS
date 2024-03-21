namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerNSymbol : Symbol
{
    private LowerNSymbol(Game game) : base(game) { }
    public override char Character => 'n';
    public override string Name => "Naga";
}
