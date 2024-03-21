[Serializable]
internal class LowerQSymbol : Symbol
{
    private LowerQSymbol(Game game) : base(game) { }
    public override char Character => 'q';
    public override string Name => "Quadruped";
}