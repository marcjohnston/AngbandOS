[Serializable]
internal class LowerASymbol : Symbol
{
    private LowerASymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'a';
    public override string Name => "Ant";
}