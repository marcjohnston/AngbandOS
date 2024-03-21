[Serializable]
internal class SpaceBarSymbol : Symbol
{
    private SpaceBarSymbol(Game game) : base(game) { }
    public override char Character => ' ';
    public override string Name => "A dark grid";
}