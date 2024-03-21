[Serializable]
internal class UpperESymbol : Symbol
{
    private UpperESymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'E';
    public override string Name => "Elemental";
}