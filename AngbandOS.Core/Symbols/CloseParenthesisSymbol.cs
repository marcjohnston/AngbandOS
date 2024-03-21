[Serializable]
internal class CloseParenthesisSymbol : Symbol
{
    private CloseParenthesisSymbol(Game game) : base(game) { }
    public override char Character => ')';
    public override string Name => "A shield";
}