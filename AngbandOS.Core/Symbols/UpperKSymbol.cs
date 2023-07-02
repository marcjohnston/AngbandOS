[Serializable]
internal class UpperKSymbol : Symbol
{
    private UpperKSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'K';
    public override string Name => "Killer Beetle";
}