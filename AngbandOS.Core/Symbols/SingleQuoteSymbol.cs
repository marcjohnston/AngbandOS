[Serializable]
internal class SingleQuoteSymbol : Symbol
{
    private SingleQuoteSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '\'';
    public override string Name => "An open door";
}