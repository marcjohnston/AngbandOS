[Serializable]
internal class PlusSignSymbol : Symbol
{
    private PlusSignSymbol(Game game) : base(game) { }
    public override char Character => '+';
    public override string Name => "A closed door";
}