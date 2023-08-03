[Serializable]
internal class UpperRSymbol : Symbol
{
    private UpperRSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'R';
    public override string Name => "Reptile/Amphibian";
}