[Serializable]
internal class PoundSignSymbol : Symbol
{
    private PoundSignSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '#';
    public override string Name => "A wall (or secret door)";
}