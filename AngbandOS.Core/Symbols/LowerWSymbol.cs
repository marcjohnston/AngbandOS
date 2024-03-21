[Serializable]
internal class LowerWSymbol : Symbol
{
    private LowerWSymbol(Game game) : base(game) { }
    public override char Character => 'w';
    public override string Name => "Worm/Worm-Mass";
}