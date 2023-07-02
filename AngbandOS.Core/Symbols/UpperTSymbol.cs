[Serializable]
internal class UpperTSymbol : Symbol
{
    private UpperTSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'T';
    public override string Name => "Troll";
}