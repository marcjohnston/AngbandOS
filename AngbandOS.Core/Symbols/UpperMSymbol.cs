[Serializable]
internal class UpperMSymbol : Symbol
{
    private UpperMSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'M';
    public override string Name => "Multi-Headed Reptile";
}