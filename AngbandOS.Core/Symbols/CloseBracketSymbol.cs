[Serializable]
internal class CloseBracketSymbol : Symbol
{
    private CloseBracketSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '}';
    public override string Name => "A launcher (bow/crossbow/sling)";
}