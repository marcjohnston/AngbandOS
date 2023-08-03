[Serializable]
internal class LowerSSymbol : Symbol
{
    private LowerSSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 's';
    public override string Name => "Skeleton";
}