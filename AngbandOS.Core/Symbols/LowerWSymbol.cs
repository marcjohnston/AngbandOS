[Serializable]
internal class LowerWSymbol : Symbol
{
    private LowerWSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'w';
    public override string Name => "Worm/Worm-Mass";
}