[Serializable]
internal class LowerCSymbol : Symbol
{
    private LowerCSymbol(Game game) : base(game) { }
    public override char Character => 'c';
    public override string Name => "Centipede";
}