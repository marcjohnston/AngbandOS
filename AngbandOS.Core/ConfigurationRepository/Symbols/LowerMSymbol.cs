[Serializable]
internal class LowerMSymbol : Symbol
{
    private LowerMSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'm';
    public override string Name => "Mold";
}