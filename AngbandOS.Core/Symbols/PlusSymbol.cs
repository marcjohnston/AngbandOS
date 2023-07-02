[Serializable]
internal class PlusSymbol : Symbol
{
    private PlusSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '+';
    public override string Name => "A closed door";
}