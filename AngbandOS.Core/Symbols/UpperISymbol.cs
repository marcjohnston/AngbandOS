[Serializable]
internal class UpperISymbol : Symbol
{
    private UpperISymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'I';
    public override string Name => "Insect";
}