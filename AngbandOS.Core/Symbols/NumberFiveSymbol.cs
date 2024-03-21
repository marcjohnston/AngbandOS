[Serializable]
internal class NumberFiveSymbol : Symbol
{
    private NumberFiveSymbol(Game game) : base(game) { }
    public override char Character => '5';
    public override string Name => "Entrance to Alchemy shop";
}