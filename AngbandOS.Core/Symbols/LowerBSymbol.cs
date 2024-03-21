namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerBSymbol : Symbol
{
    private LowerBSymbol(Game game) : base(game) { }
    public override char Character => 'b';
    public override string Name => "Bat";
}
