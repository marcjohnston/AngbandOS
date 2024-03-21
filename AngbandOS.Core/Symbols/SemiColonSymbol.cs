[Serializable]
internal class SemiColonSymbol : Symbol
{
    private SemiColonSymbol(Game game) : base(game) { }
    public override char Character => ';';
    public override string Name => "An Elder Sign / Yellow Sign";
}