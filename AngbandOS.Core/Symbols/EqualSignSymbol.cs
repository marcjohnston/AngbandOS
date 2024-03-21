[Serializable]
internal class EqualSignSymbol : Symbol
{
    private EqualSignSymbol(Game game) : base(game) { }
    public override char Character => '=';
    public override string Name => "A ring";
}