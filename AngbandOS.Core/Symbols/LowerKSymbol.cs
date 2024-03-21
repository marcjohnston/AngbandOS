[Serializable]
internal class LowerKSymbol : Symbol
{
    private LowerKSymbol(Game game) : base(game) { }
    public override char Character => 'k';
    public override string Name => "Kobold";
}