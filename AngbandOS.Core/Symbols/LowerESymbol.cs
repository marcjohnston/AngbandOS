[Serializable]
internal class LowerESymbol : Symbol
{
    private LowerESymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'e';
    public override string Name => "Floating Eye";
}