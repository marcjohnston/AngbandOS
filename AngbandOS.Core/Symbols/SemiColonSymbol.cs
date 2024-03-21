[Serializable]
internal class SemiColonSymbol : Symbol
{
    private SemiColonSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => ';';
    public override string Name => "An Elder Sign / Yellow Sign";
}