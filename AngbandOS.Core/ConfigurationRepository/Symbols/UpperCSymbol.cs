[Serializable]
internal class UpperCSymbol : Symbol
{
    private UpperCSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'C';
    public override string Name => "Canine";
}