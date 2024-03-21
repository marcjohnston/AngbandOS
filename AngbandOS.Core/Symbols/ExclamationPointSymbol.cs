[Serializable]
internal class ExclamationPointSymbol : Symbol
{
    private ExclamationPointSymbol(Game game) : base(game) { }
    public override char Character => '!';
    public override string Name => "A potion (or oil)";
}