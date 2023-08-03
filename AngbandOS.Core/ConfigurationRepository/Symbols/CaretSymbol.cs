[Serializable]
internal class CaretSymbol : Symbol
{
    private CaretSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '^';
    public override string Name => "A trap";
}