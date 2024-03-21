namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerRSymbol : Symbol
{
    private LowerRSymbol(Game game) : base(game) { }
    public override char Character => 'r';
    public override string Name => "Rodent";
}
