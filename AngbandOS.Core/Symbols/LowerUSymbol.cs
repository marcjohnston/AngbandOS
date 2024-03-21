[Serializable]
internal class LowerUSymbol : Symbol
{
    private LowerUSymbol(Game game) : base(game) { }
    public override char Character => 'u';
    public override string Name => "Minor Demon";
}