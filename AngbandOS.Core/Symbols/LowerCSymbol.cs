[Serializable]
internal class LowerCSymbol : Symbol
{
    private LowerCSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'c';
    public override string Name => "Centipede";
}