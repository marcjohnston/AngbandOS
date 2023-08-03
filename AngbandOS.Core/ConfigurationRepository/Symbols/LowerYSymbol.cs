[Serializable]
internal class LowerYSymbol : Symbol
{
    private LowerYSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'y';
    public override string Name => "Yeek";
}