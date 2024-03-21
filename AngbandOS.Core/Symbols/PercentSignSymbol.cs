[Serializable]
internal class PercentSignSymbol : Symbol
{
    private PercentSignSymbol(Game game) : base(game) { }
    public override char Character => '%';
    public override string Name => "A vein (magma or quartz)";
}