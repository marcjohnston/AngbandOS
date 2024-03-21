[Serializable]
internal class LowerMSymbol : Symbol
{
    private LowerMSymbol(Game game) : base(game) { }
    public override char Character => 'm';
    public override string Name => "Mold";
}