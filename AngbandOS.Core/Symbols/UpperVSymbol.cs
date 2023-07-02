[Serializable]
internal class UpperVSymbol : Symbol
{
    private UpperVSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'V';
    public override string Name => "Vampire";
}