[Serializable]
internal class CloseParenthesisSymbol : Symbol
{
    private CloseParenthesisSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => ')';
    public override string Name => "A shield";
}