[Serializable]
internal class PoundSignSymbol : Symbol
{
    private PoundSignSymbol(Game game) : base(game) { }
    public override char Character => '#';
    public override string Name => "A wall (or secret door)";
}