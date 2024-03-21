[Serializable]
internal class LowerGSymbol : Symbol
{
    private LowerGSymbol(Game game) : base(game) { }
    public override char Character => 'g';
    public override string Name => "Golem";
}