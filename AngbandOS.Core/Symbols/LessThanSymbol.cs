namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LessThanSymbol : Symbol
{
    private LessThanSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '<';
    public override string Name => "An up staircase";
}
