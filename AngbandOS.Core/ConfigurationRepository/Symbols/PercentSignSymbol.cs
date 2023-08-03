[Serializable]
internal class PercentSignSymbol : Symbol
{
    private PercentSignSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '%';
    public override string Name => "A vein (magma or quartz)";
}