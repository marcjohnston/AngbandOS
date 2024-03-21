[Serializable]
internal class LowerKSymbol : Symbol
{
    private LowerKSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'k';
    public override string Name => "Kobold";
}