[Serializable]
internal class UpperZSymbol : Symbol
{
    private UpperZSymbol(Game game) : base(game) { }
    public override char Character => 'Z';
    public override string Name => "Zephyr Hound";
}