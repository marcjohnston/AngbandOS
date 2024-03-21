namespace AngbandOS.Core.Symbols;

[Serializable]
internal class OpenParenthesisSymbol : Symbol
{
    private OpenParenthesisSymbol(Game game) : base(game) { }
    public override char Character => '(';
    public override string Name => "Soft armor";
}
