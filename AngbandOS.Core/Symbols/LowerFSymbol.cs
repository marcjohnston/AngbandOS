namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerFSymbol : Symbol
{
    private LowerFSymbol(Game game) : base(game) { }
    public override char Character => 'f';
    public override string Name => "Feline";
}
