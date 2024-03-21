[Serializable]
internal class CloseBracketSymbol : Symbol
{
    private CloseBracketSymbol(Game game) : base(game) { }
    public override char Character => '}';
    public override string Name => "A launcher (bow/crossbow/sling)";
}