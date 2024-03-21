[Serializable]
internal class LowerESymbol : Symbol
{
    private LowerESymbol(Game game) : base(game) { }
    public override char Character => 'e';
    public override string Name => "Floating Eye";
}