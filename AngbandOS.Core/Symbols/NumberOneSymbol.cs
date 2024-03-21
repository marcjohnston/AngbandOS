[Serializable]
internal class NumberOneSymbol : Symbol
{
    private NumberOneSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '1';
    public override string Name => "Entrance to General Store";
}