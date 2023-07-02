[Serializable]
internal class NumberNineSymbol : Symbol
{
    private NumberNineSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '9';
    public override string Name => "Entrance to Bookstore";
}