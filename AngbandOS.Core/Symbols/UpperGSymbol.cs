[Serializable]
internal class UpperGSymbol : Symbol
{
    private UpperGSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'G';
    public override string Name => "Ghost";
}