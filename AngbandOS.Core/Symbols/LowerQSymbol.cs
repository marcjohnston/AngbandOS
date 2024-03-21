[Serializable]
internal class LowerQSymbol : Symbol
{
    private LowerQSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'q';
    public override string Name => "Quadruped";
}