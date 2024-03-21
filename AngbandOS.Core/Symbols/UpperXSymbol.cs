[Serializable]
internal class UpperXSymbol : Symbol
{
    private UpperXSymbol(Game game) : base(game) { }
    public override char Character => 'X';
    public override string Name => "Extradimensional Entity";
}