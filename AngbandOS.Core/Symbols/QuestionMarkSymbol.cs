[Serializable]
internal class QuestionMarkSymbol : Symbol
{
    private QuestionMarkSymbol(Game game) : base(game) { }
    public override char Character => '?';
    public override string Name => "A scroll";
}