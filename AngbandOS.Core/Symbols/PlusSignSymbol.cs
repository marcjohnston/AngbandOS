[Serializable]
internal class PlusSignSymbol : Symbol
{
    private PlusSignSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '+';
    public override string Name => "A closed door";
}