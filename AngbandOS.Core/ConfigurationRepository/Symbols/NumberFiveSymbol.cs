[Serializable]
internal class NumberFiveSymbol : Symbol
{
    private NumberFiveSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '5';
    public override string Name => "Entrance to Alchemy shop";
}