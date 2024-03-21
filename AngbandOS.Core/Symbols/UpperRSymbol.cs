[Serializable]
internal class UpperRSymbol : Symbol
{
    private UpperRSymbol(Game game) : base(game) { }
    public override char Character => 'R';
    public override string Name => "Reptile/Amphibian";
}