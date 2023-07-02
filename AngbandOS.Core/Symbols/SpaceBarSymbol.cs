[Serializable]
internal class SpaceBarSymbol : Symbol
{
    private SpaceBarSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => ' ';
    public override string Name => "A dark grid";
}