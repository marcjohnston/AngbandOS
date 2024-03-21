namespace AngbandOS.Core.Symbols;

[Serializable]
internal class CommaSymbol : Symbol
{
    private CommaSymbol(Game game) : base(game) { }
    public override char Character => ',';
    public override string Name => "Food (or mushroom patch)";
}
