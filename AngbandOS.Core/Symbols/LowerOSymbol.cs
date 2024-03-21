[Serializable]
internal class LowerOSymbol : Symbol
{
    private LowerOSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'o';
    public override string Name => "Orc";
}