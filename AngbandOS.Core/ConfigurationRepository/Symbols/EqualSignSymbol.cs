[Serializable]
internal class EqualSignSymbol : Symbol
{
    private EqualSignSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '=';
    public override string Name => "A ring";
}