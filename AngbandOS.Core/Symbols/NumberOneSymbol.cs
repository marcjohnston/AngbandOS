[Serializable]
internal class NumberOneSymbol : Symbol
{
    private NumberOneSymbol(Game game) : base(game) { }
    public override char Character => '1';
    public override string Name => "Entrance to General Store";
}