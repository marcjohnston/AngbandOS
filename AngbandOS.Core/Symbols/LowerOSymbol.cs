[Serializable]
internal class LowerOSymbol : Symbol
{
    private LowerOSymbol(Game game) : base(game) { }
    public override char Character => 'o';
    public override string Name => "Orc";
}