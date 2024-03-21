[Serializable]
internal class NumberNineSymbol : Symbol
{
    private NumberNineSymbol(Game game) : base(game) { }
    public override char Character => '9';
    public override string Name => "Entrance to Bookstore";
}