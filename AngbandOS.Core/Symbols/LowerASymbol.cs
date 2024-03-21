[Serializable]
internal class LowerASymbol : Symbol
{
    private LowerASymbol(Game game) : base(game) { }
    public override char Character => 'a';
    public override string Name => "Ant";
}