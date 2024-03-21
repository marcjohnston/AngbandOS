namespace AngbandOS.Core.Symbols;

[Serializable]
internal class AtSymbol : Symbol
{
    private AtSymbol(Game game) : base(game) { }
    public override char Character => '@';
    public override string Name => "You (or the entrance to your home)";
}
