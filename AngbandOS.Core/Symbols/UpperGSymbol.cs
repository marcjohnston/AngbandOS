[Serializable]
internal class UpperGSymbol : Symbol
{
    private UpperGSymbol(Game game) : base(game) { }
    public override char Character => 'G';
    public override string Name => "Ghost";
}