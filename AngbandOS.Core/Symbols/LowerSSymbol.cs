[Serializable]
internal class LowerSSymbol : Symbol
{
    private LowerSSymbol(Game game) : base(game) { }
    public override char Character => 's';
    public override string Name => "Skeleton";
}