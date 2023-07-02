[Serializable]
internal class MinusSignSymbol : Symbol
{
    private MinusSignSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '-';
    public override string Name => "A wand (or rod)";
}