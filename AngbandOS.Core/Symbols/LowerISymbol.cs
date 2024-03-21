[Serializable]
internal class LowerISymbol : Symbol
{
    private LowerISymbol(Game game) : base(game) { }
    public override char Character => 'i';
    public override string Name => "Icky Thing";
}