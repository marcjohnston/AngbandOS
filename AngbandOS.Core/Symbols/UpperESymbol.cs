[Serializable]
internal class UpperESymbol : Symbol
{
    private UpperESymbol(Game game) : base(game) { }
    public override char Character => 'E';
    public override string Name => "Elemental";
}