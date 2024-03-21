[Serializable]
internal class UpperCSymbol : Symbol
{
    private UpperCSymbol(Game game) : base(game) { }
    public override char Character => 'C';
    public override string Name => "Canine";
}