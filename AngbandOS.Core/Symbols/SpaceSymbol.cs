[Serializable]
internal class SpaceSymbol : Symbol
{
    private SpaceSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => ' ';
    public override string Name => "A dark grid";
}