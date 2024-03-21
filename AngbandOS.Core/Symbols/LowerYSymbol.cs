[Serializable]
internal class LowerYSymbol : Symbol
{
    private LowerYSymbol(Game game) : base(game) { }
    public override char Character => 'y';
    public override string Name => "Yeek";
}