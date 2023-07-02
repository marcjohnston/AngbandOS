[Serializable]
internal class OpenBracketSymbol : Symbol
{
    private OpenBracketSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '{';
    public override string Name => "A missile (arrow/bolt/shot)";
}