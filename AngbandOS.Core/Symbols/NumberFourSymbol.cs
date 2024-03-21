namespace AngbandOS.Core.Symbols;

[Serializable]
internal class NumberFourSymbol : Symbol
{
    private NumberFourSymbol(Game game) : base(game) { }
    public override char Character => '4';
    public override string Name => "Entrance to Temple";
}
