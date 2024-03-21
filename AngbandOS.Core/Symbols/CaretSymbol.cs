[Serializable]
internal class CaretSymbol : Symbol
{
    private CaretSymbol(Game game) : base(game) { }
    public override char Character => '^';
    public override string Name => "A trap";
}