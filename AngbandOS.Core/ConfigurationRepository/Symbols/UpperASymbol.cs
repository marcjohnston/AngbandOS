[Serializable]
internal class UpperASymbol : Symbol
{
    private UpperASymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'A';
    public override string Name => "Abomination";
}