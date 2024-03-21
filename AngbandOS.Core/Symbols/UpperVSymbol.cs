[Serializable]
internal class UpperVSymbol : Symbol
{
    private UpperVSymbol(Game game) : base(game) { }
    public override char Character => 'V';
    public override string Name => "Vampire";
}