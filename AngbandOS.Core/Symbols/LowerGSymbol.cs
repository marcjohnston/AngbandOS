[Serializable]
internal class LowerGSymbol : Symbol
{
    private LowerGSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'g';
    public override string Name => "Golem";
}