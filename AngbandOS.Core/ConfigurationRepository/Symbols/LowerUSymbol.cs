[Serializable]
internal class LowerUSymbol : Symbol
{
    private LowerUSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'u';
    public override string Name => "Minor Demon";
}