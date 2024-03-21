namespace AngbandOS.Core.Symbols;

[Serializable]
internal class CloseBraceSymbol : Symbol
{
    private CloseBraceSymbol(Game game) : base(game) { }
    public override char Character => ']';
    public override string Name => "Misc. armor";
}
