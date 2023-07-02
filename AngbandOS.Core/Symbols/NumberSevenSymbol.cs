[Serializable]
internal class NumberSevenSymbol : Symbol
{
    private NumberSevenSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '7';
    public override string Name => "Entrance to Black Market";
}