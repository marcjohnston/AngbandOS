[Serializable]
internal class ExclamationPointSymbol : Symbol
{
    private ExclamationPointSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '!';
    public override string Name => "A potion (or oil)";
}