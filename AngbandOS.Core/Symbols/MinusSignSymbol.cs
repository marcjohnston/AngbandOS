[Serializable]
internal class MinusSignSymbol : Symbol
{
    private MinusSignSymbol(Game game) : base(game) { }
    public override char Character => '-';
    public override string Name => "A wand (or rod)";
}