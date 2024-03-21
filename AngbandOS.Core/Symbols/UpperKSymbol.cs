[Serializable]
internal class UpperKSymbol : Symbol
{
    private UpperKSymbol(Game game) : base(game) { }
    public override char Character => 'K';
    public override string Name => "Killer Beetle";
}