[Serializable]
internal class UpperASymbol : Symbol
{
    private UpperASymbol(Game game) : base(game) { }
    public override char Character => 'A';
    public override string Name => "Abomination";
}