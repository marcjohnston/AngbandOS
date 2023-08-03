[Serializable]
internal class UpperXSymbol : Symbol
{
    private UpperXSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'X';
    public override string Name => "Extradimensional Entity";
}