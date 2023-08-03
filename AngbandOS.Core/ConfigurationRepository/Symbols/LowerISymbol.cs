[Serializable]
internal class LowerISymbol : Symbol
{
    private LowerISymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'i';
    public override string Name => "Icky Thing";
}