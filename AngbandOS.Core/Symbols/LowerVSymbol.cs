namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LowerVSymbol : Symbol
{
    private LowerVSymbol(Game game) : base(game) { }
    public override char Character => 'v';
    public override string Name => "Vortex";
}
