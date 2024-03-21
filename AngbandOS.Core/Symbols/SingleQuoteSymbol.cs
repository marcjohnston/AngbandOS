[Serializable]
internal class SingleQuoteSymbol : Symbol
{
    private SingleQuoteSymbol(Game game) : base(game) { }
    public override char Character => '\'';
    public override string Name => "An open door";
}