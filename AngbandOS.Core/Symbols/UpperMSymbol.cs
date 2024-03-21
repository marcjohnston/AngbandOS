[Serializable]
internal class UpperMSymbol : Symbol
{
    private UpperMSymbol(Game game) : base(game) { }
    public override char Character => 'M';
    public override string Name => "Multi-Headed Reptile";
}