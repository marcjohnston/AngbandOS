namespace AngbandOS.Core.Symbols;

[Serializable]
internal class TildeSymbol : Symbol
{
    private TildeSymbol(Game game) : base(game) { }
    public override char Character => '~';
    public override string Name => "A tool (or miscellaneous item)";
}
