[Serializable]
internal class UpperTSymbol : Symbol
{
    private UpperTSymbol(Game game) : base(game) { }
    public override char Character => 'T';
    public override string Name => "Troll";
}