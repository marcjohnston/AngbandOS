[Serializable]
internal class OpenBracketSymbol : Symbol
{
    private OpenBracketSymbol(Game game) : base(game) { }
    public override char Character => '{';
    public override string Name => "A missile (arrow/bolt/shot)";
}