[Serializable]
internal class NumberSevenSymbol : Symbol
{
    private NumberSevenSymbol(Game game) : base(game) { }
    public override char Character => '7';
    public override string Name => "Entrance to Black Market";
}