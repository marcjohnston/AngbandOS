[Serializable]
internal class UpperISymbol : Symbol
{
    private UpperISymbol(Game game) : base(game) { }
    public override char Character => 'I';
    public override string Name => "Insect";
}