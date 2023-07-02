[Serializable]
internal class QuestionMarkSymbol : Symbol
{
    private QuestionMarkSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '?';
    public override string Name => "A scroll";
}