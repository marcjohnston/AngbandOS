namespace AngbandOS.Core.Symbols;

[Serializable]
internal class LessThanSymbol : Symbol
{
    private LessThanSymbol(Game game) : base(game) { }
    public override char Character => '<';
    public override string Name => "An up staircase";
}
