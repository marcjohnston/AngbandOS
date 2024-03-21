[Serializable]
internal class UpperZSymbol : Symbol
{
    private UpperZSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => 'Z';
    public override string Name => "Zephyr Hound";
}